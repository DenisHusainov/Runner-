public interface IPoolable<T>
{
    void Initialize();
    void ReturnToPool();
    void SpawnFromPool();
}