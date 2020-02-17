using System.Collections.Generic;

namespace SimonsVoss.Infra.Interfaces
{
    public interface ISearchWeightRepository
    {
        IEnumerable<ISearchWeightConfiguration> GetAllData();
    }
}
