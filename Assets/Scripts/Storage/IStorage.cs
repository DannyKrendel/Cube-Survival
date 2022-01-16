public interface IStorage<out T>
{
    T Get(string key);
}