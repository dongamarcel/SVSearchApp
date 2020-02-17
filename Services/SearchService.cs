using SimonsVoss.Infra.Factory;
using SimonsVoss.Infra.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace Services
{
    public class SearchService : ISearchService
    {
        public SearchService()
        {
            var searchRepository = DependencyFactory.Instance.Resolve<ISearchRepository>();
            var searchWeightRepository = DependencyFactory.Instance.Resolve<ISearchWeightRepository>();
            searchConfiguration = DependencyFactory.Instance.Resolve<ISearchConfiguration>();
            searchData = searchRepository.GetAllData();
            searchWeightConfigurations = searchWeightRepository.GetAllData();
        }

        private readonly ISearchConfiguration searchConfiguration;
        private readonly IRootObject searchData;
        private readonly IEnumerable<ISearchWeightConfiguration> searchWeightConfigurations;

        public IEnumerable<ISearchResult> Search(string input)
        {
            List<ISearchResult> searchResults = searchData.SearchModels.Select(m => 
            {
                var result = DependencyFactory.Instance.Resolve<ISearchResult>();
                result.Result = m;
                return result;
            }).ToList();

            if (string.IsNullOrEmpty(input))
                return searchResults;

            foreach (var searchableItem in searchResults)
                Weight(input, searchableItem, searchResults);

            return searchResults.Where(o  => o.Weight > 0).OrderByDescending(o => o.Weight);
        }

        private void Weight (string input, ISearchResult searchableItem, List<ISearchResult> weightedItems)
        {
            Type fieldType = searchableItem.Result.GetType();
            PropertyInfo[] properties = fieldType.GetProperties();
            string UUID = searchableItem.Result.id;

            foreach (var property in properties)
            {
                ISearchWeightConfiguration fieldConfiguration = GetFieldConfiguration(fieldType, property.Name);

                if (fieldConfiguration == null)
                    continue;

                string value = property.GetValue(searchableItem.Result)?.ToString();
                if (string.IsNullOrEmpty(value))
                    continue;

                if (value.ToLower().Equals(input.ToLower()))
                    searchableItem.Weight += fieldConfiguration.Weight * searchConfiguration.FactorCompleteMatch;
                else if (value.ToLower().Contains(input.ToLower()))
                    searchableItem.Weight += fieldConfiguration.Weight;
                else continue;

                if (fieldConfiguration.CrossReferencedType != null)
                    ApplyWeightCrossReference(UUID, fieldConfiguration.CrossReferencedType, fieldConfiguration.CrossReferencedWeight, weightedItems);
            }
        }

        private void ApplyWeightCrossReference(string uUID, Type fieldType, int weight, List<ISearchResult> searchableItems)
        {
            foreach(var searchableItem in searchableItems.Where(a => a.Result.foreignID.Equals(uUID) && a.Result.GetType() == fieldType))
                searchableItem.Weight += weight;
        }

        private ISearchWeightConfiguration GetFieldConfiguration(Type type, string fieldName) => searchWeightConfigurations.FirstOrDefault(f => f.Type == type && f.FieldName == fieldName);
    }
}
