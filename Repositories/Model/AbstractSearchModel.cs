using SimonsVoss.Infra.Interfaces;

namespace Repositories.Model
{
    public class AbstractSearchModel : ISearchModel
    {
        public string id { get; set; }
        public string buildingId { get; set; }
        public string shortCut { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string serialNumber { get; set; }
        public string floor { get; set; }
        public string roomNumber { get; set; }
        public virtual string foreignID { get => string.Empty; }
        public string groupId { get; set; }
        public string owner { get; set; }
        public string objectType { get => this.GetType().Name; }
    }
}
