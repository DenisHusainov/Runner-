using UnityEngine;

public interface IPool
{
    T Get<T>() where T: Poolable;
}
