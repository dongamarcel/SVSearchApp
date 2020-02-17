using System.Collections.Generic;

namespace SimonsVoss.Infra.Interfaces
{
    public interface ISearchService
    {
        IEnumerable<ISearchResult> Search(string input);
    }
}
