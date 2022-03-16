using System;
using UnityEngine;

public class PoolReturn : MonoBehaviour, IPoolable<PoolReturn>
{
    private Action<PoolReturn> _returnToPool = delegate { };

    private void OnDisable()
    {
        ReturnToPool();
    }

    public void Initialize(Action<PoolReturn> returnAction)
    {
        _returnToPool = returnAction;
    }

    public void ReturnToPool()
    {
        _returnToPool(this);
    }
}