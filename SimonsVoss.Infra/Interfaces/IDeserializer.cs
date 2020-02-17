namespace SimonsVoss.Infra.Interfaces
{
    public interface IDeserializer
    {
        T Deserialize<T>(string stringToDeserialize);
    }
}
