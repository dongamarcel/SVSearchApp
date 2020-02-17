using SimonsVoss.Infra.Interfaces;
using System.IO;

namespace SearchUnitTests
{
    internal class SearchDataProviderMock : ISearchDataProvider
    {
        private readonly string jsonStringPath;

        public SearchDataProviderMock()
        {
            jsonStringPath = string.Concat(Directory.GetCurrentDirectory(), "\\Resources\\sv_lsm_data.json");
        }

        public string GetData() => File.ReadAllText(jsonStringPath);
    }
}
