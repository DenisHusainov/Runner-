using UnityEngine;

public abstract class Detected : MonoBehaviour
{
    public abstract void DetectedObject();
   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            DetectedObject();
        }
    }
}
