using UnityEngine;

public class Poolable : MonoBehaviour
{
    public void Initialize()
    {
        
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
    }

    public void SpawnFromPool()
    {
        gameObject.SetActive(true);
    }
}
