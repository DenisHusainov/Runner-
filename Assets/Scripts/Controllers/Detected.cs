using UnityEngine;

public abstract class Detected : MonoBehaviour
{
    public abstract void DetectedObject(PlayerController player);
   
    void OnTriggerEnter(Collider other)
    {
        var playerContoller = other.gameObject.GetComponent<PlayerController>();

        if (playerContoller)
        {
            DetectedObject(playerContoller);
        }
    }
}
