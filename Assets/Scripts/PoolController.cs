using System;
using System.Collections.Generic;
using UnityEngine;

public enum PoolType
{
    Player,
    Enemy
}

[Serializable]
public class PoolInfo
{
    public PoolType type = default;
    public int amount = default;
    public GameObject prefab = null;
    public GameObject container = null;

    public Queue<GameObject> Pool = new Queue<GameObject>();
}

public class PoolController : MonoBehaviour
{
    [SerializeField]
    private List<PoolInfo> pools;

    public static PoolController Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }

        foreach (var pool in pools)
        {
            InitPool(pool);
        }
    }

    private void InitPool(PoolInfo pool)
    {
        for (int i = 0; i < pool.amount; i++)
        {
            GameObject obj = Instantiate(pool.prefab, pool.container.transform);
            obj.SetActive(false);
            pool.Pool.Enqueue(obj);
        }
    }

    public GameObject GetPoolObject(PoolType type)
    {
        PoolInfo selected = GetPoolByType(type);

        if (selected == null)
            return null;

        GameObject obj;
        if (selected.Pool.Count > 0)
        {
            obj = selected.Pool.Dequeue();
        }
        else
        {
            obj = Instantiate(selected.prefab, selected.container.transform);
            selected.Pool.Enqueue(obj);
        }

        return obj;
    }

    public void ReturnObjectToPool(GameObject obj, PoolType type)
    {
        PoolInfo selected = GetPoolByType(type);

        if (selected == null)
            return;

        obj.SetActive(false);
        selected.Pool.Enqueue(obj);
    }

    private PoolInfo GetPoolByType(PoolType type)
    {
        foreach (var pool in pools)
        {
            if (pool.type == type)
                return pool;
        }

        return null;
    }
}
