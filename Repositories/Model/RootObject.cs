using SimonsVoss.Infra.Interfaces;
using System.Collections.Generic;

namespace Model
{
    public class RootObject
    {
        public List<Building> buildings { get; set; }
        public List<Lock> locks { get; set; }
        public List<Group> groups { get; set; }
        public List<Medium> media { get; set; }
    }

    public class RootObjectWrapper : IRootObject
    {
        public RootObjectWrapper(RootObject rootObject)
        {
            var listOfSearchModels = new List<ISearchModel>();
            listOfSearchModels.AddRange(rootObject.buildings);
            listOfSearchModels.AddRange(rootObject.groups);
            listOfSearchModels.AddRange(rootObject.locks);
            listOfSearchModels.AddRange(rootObject.media);

            SearchModels = listOfSearchModels;
        }

        public IEnumerable<ISearchModel> SearchModels { get; private set; }
    }
}
