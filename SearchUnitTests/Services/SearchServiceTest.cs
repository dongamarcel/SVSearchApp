using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Repositories;
using Repositories.Model;
using Services;
using Services.Configuration;
using SimonsVoss.Infra.Concretes;
using SimonsVoss.Infra.Factory;
using SimonsVoss.Infra.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SearchUnitTests
{
    [TestClass]
    public class SearchServiceTest
    {
        private void RegisterCommonTypes()
        {
            DependencyFactory.Instance.AddScoped<IDeserializer>(typeof(JsonDeserializer));
            DependencyFactory.Instance.AddScoped<ISearchRepository>(typeof(SearchRepository));
            DependencyFactory.Instance.AddScoped<ISearchDataProvider>(typeof(SearchDataProviderMock));
            DependencyFactory.Instance.AddScoped<ISearchWeightRepository>(typeof(SearchWeightRepository));
            DependencyFactory.Instance.AddScoped<ISearchWeightConfiguration>(typeof(SearchWeightConfiguration));
            DependencyFactory.Instance.AddScoped<ISearchService>(typeof(SearchService));
            DependencyFactory.Instance.AddTransient<ISearchResult>(typeof(SearchResult));
            DependencyFactory.Instance.AddTransient<ISearchConfiguration>(typeof(DefaultSearchConfiguration));
            DependencyFactory.Instance.Init();
        }

        [TestMethod]
        public void SearchTest()
        {
            var results = prepareAndSearch("head");
            //Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
            Assert.IsFalse(results.Any(r => r.Weight == 0));
            Assert.IsTrue(results.FirstOrDefault().Result is Building);
        }

        [TestMethod]
        public void SearchFullMatchTest()
        {
            var results = prepareAndSearch("Head Office");

            //Assert
            Assert.IsNotNull(results);
            Assert.IsTrue(results.Any());
            Assert.IsFalse(results.Any(r => r.Weight == 0));
            Assert.IsTrue(results.FirstOrDefault().Result is Building);
            Assert.IsTrue(results.FirstOrDefault().Weight.Equals(95));
        }

        [TestMethod]
        public void SearchByDescriptionTest()
        {
            var results = prepareAndSearch("Head Office, Feringastraße 4,");

            //Assert
            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Result is Building);
        }

        [TestMethod]
        public void SearchByBuildingShortCut()
        {
            var results = prepareAndSearch("HOFF");

            //Assert
            Assert.IsTrue(results.Count() == 47);
            Assert.IsTrue(results.First().Result is Building);
        }

        [TestMethod]
        public void SearchByLockName()
        {
            var results = prepareAndSearch("Swift/Bednar/Cassin");

            //Assert
            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Result is Lock);
        }

        [TestMethod]
        public void SearchByGroupName()
        {
            var results = prepareAndSearch("Reinigungsdienst");

            //Assert
            Assert.IsTrue(results.Count() == 5);
            Assert.IsTrue(results.First().Result is Group);
            Assert.IsTrue(results.Count(c => c.Result is Medium) == 4);
        }

        [TestMethod]
        public void SearchByMediaSerialNumber()
        {
            var results = prepareAndSearch("UID-378D17F6");

            //Assert
            Assert.IsTrue(results.Count() == 1);
            Assert.IsTrue(results.First().Result is Medium);
        }

        private IEnumerable<ISearchResult> prepareAndSearch(string input)
        {
            //Prepare
            RegisterCommonTypes();
            var searchService = DependencyFactory.Instance.Resolve<ISearchService>();

            //Act
            return searchService.Search(input);
        }

    }
}
