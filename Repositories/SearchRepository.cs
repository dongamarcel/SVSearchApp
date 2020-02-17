using Model;
using SimonsVoss.Infra.Factory;
using SimonsVoss.Infra.Interfaces;
using System;

namespace Repositories
{
    public class SearchRepository : ISearchRepository
    {
        IDeserializer deserializer;
        ISearchDataProvider searchDataProvider;

        public SearchRepository()
        {
            deserializer = DependencyFactory.Instance.Resolve<IDeserializer>();
            searchDataProvider = DependencyFactory.Instance.Resolve<ISearchDataProvider>();
        }

        public IRootObject GetAllData()
        {
            string serializedData = searchDataProvider.GetData();

            if (string.IsNullOrEmpty(serializedData))
                throw new FormatException();

            return new RootObjectWrapper(deserializer.Deserialize<RootObject>(serializedData));
        }
    }
}
