using System.Collections.Generic;

namespace SimonsVoss.Infra.Interfaces
{
    public interface IRootObject
    {
        IEnumerable<ISearchModel> SearchModels { get; }
    }
}
