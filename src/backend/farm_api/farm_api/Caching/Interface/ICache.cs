namespace farm_api.Caching.Interface
{
    public interface ICache
    {
        T Get<T>(string key);
        void Set<T>(string key, T value, TimeSpan duration);
        bool TryGetValue<T>(string key, out T value);
        void Remove(string key);
    }
}
