using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool<T> where T : Singleton<T>, IPoolable<T>, IPool<T>
{
    private Action<T> _pullObject;
    private Action<T> _pushObject;
    private Stack<T> pooledObjects = new Stack<T>();
    private GameObject _prefab = null;

    public int PooledCount
    {
        get
        {
            return pooledObjects.Count;
        }
    }

    public ObjectPool(GameObject pooledObject, int numToSpawn = 0)
    {
        _prefab = pooledObject;
        Spawn(numToSpawn);
    }

    public ObjectPool(GameObject pooledObject, Action<T> pullObject, Action<T> pushObject, int numToSpawn = 0)
    {
        _prefab = pooledObject;
        _pullObject = pullObject;
        _pushObject = pushObject;
        Spawn(numToSpawn);
    }

    public T Pull()
    {
        T t;
        if (PooledCount > 0)
            t = pooledObjects.Pop();
        else
            t = GameObject.Instantiate(_prefab).GetComponent<T>();

        t.gameObject.SetActive(true);
        t.Initialize(Push);

        _pullObject?.Invoke(t);

        return t;
    }

    public T Pull(Vector3 position)
    {
        T t = Pull();
        t.transform.position = position;
        return t;
    }

    public T Pull(Vector3 position, Quaternion rotation)
    {
        T t = Pull();
        t.transform.position = position;
        t.transform.rotation = rotation;
        return t;
    }

    public GameObject PullGameObject()
    {
        return Pull().gameObject;
    }

    public GameObject PullGameObject(Vector3 position)
    {
        GameObject go = Pull().gameObject;
        go.transform.position = position;
        return go;
    }

    public GameObject PullGameObject(Vector3 position, Quaternion rotation)
    {
        GameObject go = Pull().gameObject;
        go.transform.position = position;
        go.transform.rotation = rotation;
        return go;
    }

    public void Push(T t)
    {
        pooledObjects.Push(t);

        _pushObject?.Invoke(t);

        t.gameObject.SetActive(false);
    }

    private void Spawn(int number)
    {
        T t;

        for (int i = 0; i < number; i++)
        {
            t = GameObject.Instantiate(_prefab).GetComponent<T>();
            pooledObjects.Push(t);
            t.gameObject.SetActive(false);
        }
    }
}

public interface IPool<T>
{
    T Pull();
    void Push(T t);
}

public interface IPoolable<T>
{
    void Initialize(Action<T> returnAction);
    void ReturnToPool();
}