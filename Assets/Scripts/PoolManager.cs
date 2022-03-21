using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolManager: Singleton<PoolManager>, IPool
{
    private Dictionary<IPoolable, Stack<IPoolable>> _pooledObjects =
        new Dictionary<IPoolable, Stack<IPoolable>>();

    [SerializeField]
    private IPoolable _prefab = default;
    [SerializeField]
    private int _amountToPool = default;

    private void Awake()
    {
        Spawn(_prefab);
    }

    private void Spawn(IPoolable objectForSpawn)
    {
        Stack<IPoolable> stack = null;

        if (!_pooledObjects.TryGetValue(_prefab, out stack))
        {
            stack = new Stack<IPoolable>();
            _pooledObjects.Add(objectForSpawn, stack);
        }   

        for (int i = 0; i < _amountToPool; i++)
        {
            var poolObject = Instantiate(objectForSpawn); 
            stack.Push(poolObject);
            poolObject.gameObject.SetActive(false);
        }
    }

    private void Push(IPoolable pollObject)
    {
        _pooledObjects.TryGetValue(_prefab, out var stack);
        stack.Push(pollObject);
    }

    public T Pull<T>() where T : Component, IPoolable
    {

        if (_pooledObjects.TryGetValue(_prefab, out var stack))
        {
            var poolObject = (T)stack.Pop();
            poolObject.SpawnFromPool();

            return poolObject;
        }

        return null;
    }
}