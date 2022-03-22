using UnityEngine;

public interface IPool
{
    T Pull<T>() where T: Poolable;
}
