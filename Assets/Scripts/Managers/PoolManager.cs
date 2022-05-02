using System.Collections.Generic;
using UnityEngine;

public class PoolManager: Singleton<PoolManager>, IPool
{
    private Dictionary<Poolable, Stack<Poolable>> _pooledObjects =
        new Dictionary<Poolable, Stack<Poolable>>();

    [SerializeField]
    private Poolable _prefab = default;

    private void Awake()
    {
        base.Awake();
        Spawn(_prefab, 50);
    }

    private void Start()
    {
        Prepare(_prefab);
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

    private void Prepare(Poolable pollObject)
    {
        _pooledObjects.TryGetValue(_prefab, out var stack);
        stack.Push(pollObject);
    }

    public T Get<T>() where T : Poolable
    {
        if (_pooledObjects.TryGetValue(_prefab, out var stack) && stack.Count > 0)
        {
            var poolObject = (T)stack.Pop();
            poolObject.SpawnFromPool();

            return poolObject;
        }
        else
        {
            Debug.LogError("This is not prepared");

            Spawn(_prefab, 1);

            return (T)_pooledObjects[_prefab].Pop();
        }
    }
}