using System;
using TMPro;
using UnityEngine;

public class BonusController : MonoBehaviour
{
    public static event Action Spawned = delegate { };

    [SerializeField]
    private TextMeshPro _bonusDoorText = null;
    [SerializeField]
    private BonusController _bonusController = null;
    [SerializeField]
    private int _setBonus = default;

    private void Start()
    {
        _bonusDoorText.text = _setBonus.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            Spawned();
            _bonusController.gameObject.SetActive(false);
        }
    }
}
