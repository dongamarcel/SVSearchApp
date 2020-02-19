using SimonsVoss.Infra.Interfaces;

namespace Repositories.Model
{
    public class SearchResult : ISearchResult
    {
        public ISearchModel Result { get; set; }
        public int Weight { get; set; }
    }
}
