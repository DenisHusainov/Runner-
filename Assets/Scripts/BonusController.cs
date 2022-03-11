using System;
using TMPro;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    public static event Action Spawed = delegate { };

    [SerializeField]
    private TextMeshPro textMeshPro = null;
    [SerializeField]
    private BonusController _bonusController = null;
    [SerializeField]
    private int _bonusNumber = default;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Spawed();
        }
    }
}
