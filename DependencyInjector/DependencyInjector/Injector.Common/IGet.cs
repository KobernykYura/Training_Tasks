namespace Injector.Common
{
    public interface IGet
    {
        T Get<T>();
        T GetByKey<T>(string key);
    }
}