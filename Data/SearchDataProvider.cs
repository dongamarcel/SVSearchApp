using SimonsVoss.Infra.Interfaces;
using System.IO;

namespace Data
{
    public class SearchDataProvider : ISearchDataProvider
    {
        private readonly string jsonStringPath;

        public SearchDataProvider(string rootPath)
        {
            jsonStringPath = string.Concat(rootPath, "\\Resources\\sv_lsm_data.json");
        }

        public string GetData() => File.ReadAllText(jsonStringPath);
    }
}
