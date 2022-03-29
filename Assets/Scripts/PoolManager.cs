using System.Collections.Generic;
using UnityEngine;

public class PoolManager: Singleton<PoolManager>, IPool
{
    private Dictionary<Poolable, Stack<Poolable>> _pooledObjects =
        new Dictionary<Poolable, Stack<Poolable>>();

    [SerializeField]
    private Poolable _prefab = default;
    [SerializeField]
    private int _amountToPool = default;

    private void Awake()
    {
        base.Awake();
        Spawn(_prefab, _amountToPool);
    }

    private void Spawn(Poolable objectForSpawn, int amountToPool)
    {
        Stack<Poolable> stack = null;

        if (!_pooledObjects.TryGetValue(_prefab, out stack))
        {
            stack = new Stack<Poolable>();
            _pooledObjects.Add(objectForSpawn, stack);
        }   

        for (int i = 0; i < amountToPool; i++)
        {
            var poolObject = Instantiate(objectForSpawn, transform.parent);
            stack.Push(poolObject);
            poolObject.gameObject.SetActive(false);
        }
    }

    private void Push(Poolable pollObject)
    {
        _pooledObjects.TryGetValue(_prefab, out var stack);
        stack.Push(pollObject);
    }

    public T Pull<T>() where T : Poolable
    {
        if (_pooledObjects.TryGetValue(_prefab, out var stack))
        {
            var poolObject = (T)stack.Pop();
            poolObject.SpawnFromPool();

            return poolObject;
        }
        else
        {
            Debug.LogError("This is not prepared");
        }

        var objectFromPool = (T)Instantiate(_prefab);

        if (objectFromPool!=null)
        {
            Spawn(_prefab, 1);
        }

        return objectFromPool;
    }
}