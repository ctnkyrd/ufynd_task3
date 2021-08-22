namespace task3.webapi.Services
{
    public interface IJsonMapper
    {
        T Deserialize<T>(T entity, string fileName);
    }
}