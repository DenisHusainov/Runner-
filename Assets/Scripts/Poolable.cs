using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poolable : MonoBehaviour, IPoolable
{
    public void Initialize()
    {
        
    }

    public void ReturnToPool()
    {
        
    }

    public void SpawnFromPool()
    {
        gameObject.SetActive(true);
    }
}
