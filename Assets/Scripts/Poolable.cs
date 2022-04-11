using UnityEngine;

public class Poolable : MonoBehaviour
{
    public bool IsFree { get; protected set; }

    public void Initialize()
    {
        
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
        IsFree = false;
    }

    public void SpawnFromPool()
    {
        gameObject.SetActive(true);
        IsFree = true;
    }
}
