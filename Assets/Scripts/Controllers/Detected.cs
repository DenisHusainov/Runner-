using UnityEngine;

public abstract class ObjectContact : MonoBehaviour
{
    public abstract void OnInteracted(PlayerController player);
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerController>(out PlayerController player))
        {
            OnInteracted(player);
        }
    }
}
