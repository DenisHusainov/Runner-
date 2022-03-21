public interface IPoolable
{
    void Initialize();
    void ReturnToPool();
    void SpawnFromPool();
}