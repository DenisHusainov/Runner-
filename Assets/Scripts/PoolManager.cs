using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolManager: Singleton<PoolManager>, IPool<PoolManager> 
{
    private Dictionary<Type, Stack<MonoBehaviour>> _pooledObjects =
        new Dictionary<Type, Stack<MonoBehaviour>>();

    [SerializeField]
    private GameObject _prefab = null;

    public int PooledCount
    {
        get
        {
            return _pooledObjects.Count;
        }
    }

    public PoolManager(GameObject pooledObject, int numToSpawn = 0)
    { 
        _prefab = pooledObject;
        Spawn(numToSpawn);
    }

    private void Spawn(int number)
    {
        PoolManager poolObject;
        

        Stack<MonoBehaviour> stack = null;

        if (!_pooledObjects.TryGetValue(_prefab.GetType(), out stack))
        {
            stack = new Stack<MonoBehaviour>();
            _pooledObjects.Add(_prefab.GetType(), stack);
        }

        for (int i = 0; i < number; i++)
        {
            poolObject = GameObject.Instantiate(_prefab).GetComponent<PoolManager>();
            stack.Push(poolObject);
            poolObject.gameObject.SetActive(false);
        }
    }

    public void Push(PoolManager pollObject)
    {
        _pooledObjects.TryGetValue(_prefab.GetType(), out var stack);
        stack.Push(pollObject);
    }

    public PoolManager Pull()
    {
        _pooledObjects.TryGetValue(_prefab.GetType(), out var stack);

        MonoBehaviour poolObject;

        if (PooledCount > 0)
            poolObject = stack.Pop();
        else
            poolObject = GameObject.Instantiate(_prefab).GetComponent<PoolManager>();

        poolObject.gameObject.SetActive(true);

        return (PoolManager)poolObject;
    }
}
