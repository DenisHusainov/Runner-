using System;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    public static event Action Won = delegate { };

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Won();
        }
    }
}
