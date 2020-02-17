using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Repositories;
using SearchUnitTests.Mocks;
using SimonsVoss.Infra.Concretes;
using SimonsVoss.Infra.Factory;
using SimonsVoss.Infra.Interfaces;
using System;
using System.IO;
using System.Linq;

namespace SearchUnitTests
{
    [TestClass]
    public class SearchRepositoryTest
    {
        private void RegisterCommonTypes()
        {
            DependencyFactory.Instance.AddScoped<IDeserializer>(typeof(JsonDeserializer));
            DependencyFactory.Instance.AddScoped<ISearchRepository>(typeof(SearchRepository));
        }

        [TestMethod]
        public void GetAllSearchDataTest()
        {
            //Prepare
            RegisterCommonTypes();
            DependencyFactory.Instance.AddSingleton<ISearchDataProvider>(new SearchDataProvider(Directory.GetCurrentDirectory()));
            DependencyFactory.Instance.Init();
            var searchRepository = DependencyFactory.Instance.Resolve<ISearchRepository>();

            //Act
            IRootObject rootObject = searchRepository.GetAllData();

            //Assert
            Assert.IsNotNull(rootObject);
            Assert.IsTrue(rootObject.SearchModels.Any());
        }

        [TestMethod]
        public void GetAllSearchDataExceptionTest()
        {
            //Prepare
            FormatException exc = null;
            RegisterCommonTypes();
            DependencyFactory.Instance.AddScoped<ISearchDataProvider>(typeof(EmptySearchDataProviderMock));
            DependencyFactory.Instance.Init();
            var searchRepository = DependencyFactory.Instance.Resolve<ISearchRepository>();

            //Act
            try
            {
                IRootObject rootObject = searchRepository.GetAllData();
            }
            catch (FormatException exception)
            {
                //Assert
                exc = exception;
            }

            //Assert
            Assert.IsNotNull(exc);
        }
    }
}
