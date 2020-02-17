using Model;
using Repositories.Model;
using SimonsVoss.Infra.Interfaces;
using System.Collections.Generic;

namespace Repositories
{
    public class SearchWeightRepository : ISearchWeightRepository
    {
        //This could have a better implementation of this interface consuming it from a JSon file or DB
        //The switch would be very simple just switching the type registered for this interface.
        public IEnumerable<ISearchWeightConfiguration> GetAllData()
        {
            yield return new SearchWeightConfiguration(typeof(Building), "shortCut", 7, 5, typeof(Lock));
            yield return new SearchWeightConfiguration(typeof(Building), "name", 9, 8, typeof(Lock));
            yield return new SearchWeightConfiguration(typeof(Building), "description", 5);

            yield return new SearchWeightConfiguration(typeof(Lock), "type", 3);
            yield return new SearchWeightConfiguration(typeof(Lock), "name", 10);
            yield return new SearchWeightConfiguration(typeof(Lock), "serialNumber", 8);
            yield return new SearchWeightConfiguration(typeof(Lock), "floor", 6);
            yield return new SearchWeightConfiguration(typeof(Lock), "roomNumber", 6);
            yield return new SearchWeightConfiguration(typeof(Lock), "description", 6);

            yield return new SearchWeightConfiguration(typeof(Group), "name", 9, 8, typeof(Medium));
            yield return new SearchWeightConfiguration(typeof(Group), "description", 5);

            yield return new SearchWeightConfiguration(typeof(Medium), "type", 3);
            yield return new SearchWeightConfiguration(typeof(Medium), "owner", 10);
            yield return new SearchWeightConfiguration(typeof(Medium), "serialNumber", 8);
            yield return new SearchWeightConfiguration(typeof(Medium), "description", 6);

        }
    }
}
