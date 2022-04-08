using System;
using UnityEngine;

public class ObstaclesController : MonoBehaviour
{
    public static event Action Crashed = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Crashed();
        }
    }
}
