public interface IPool
{
    T Get<T>() where T: Poolable;
}
