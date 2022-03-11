using System;
using TMPro;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    public static event Action Spawed = delegate { };

    [SerializeField]
    private TextMeshPro _rightBonus = null;
    [SerializeField]
    private TextMeshPro _leftBonus = null;
    [SerializeField]
    private Collider[] _bonusColiders = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Spawed();
        }
    }
}
