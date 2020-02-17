namespace SimonsVoss.Infra.Interfaces
{
    public interface ISearchResult
    {
        ISearchModel Result { get; set; }

        int Weight { get; set; }
    }
}