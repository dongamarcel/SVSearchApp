namespace SimonsVoss.Infra.Interfaces
{
    public interface ISearchModel
    {
        string id { get; set; }
        string buildingId { get; set; }
        string shortCut { get; set; }
        string type { get; set; }
        string name { get; set; }
        string description { get; set; }
        string serialNumber { get; set; }
        string floor { get; set; }
        string roomNumber { get; set; }
        string foreignID { get; }
        string groupId { get; set; }
        string owner { get; set; }
        string objectType { get; }
    }
}
