using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolManager: Singleton<PoolManager>, IPool<PoolManager> 
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
            var poolObject = Instantiate();
            stack.Push(poolObject);
            poolObject.gameObject.SetActive(false);
        }
    }

    private void Push(IPoolable pollObject)
    {
        _pooledObjects.TryGetValue(_prefab, out var stack);
        stack.Push(pollObject);
    }

    public PoolManager Pull()
    {
        if (_pooledObjects.TryGetValue(_prefab, out var stack))
        {
            stack.Pop();
        }

        IPoolable poolObject;

        //Pooble.SpanwFromPull();

        return
    }
}