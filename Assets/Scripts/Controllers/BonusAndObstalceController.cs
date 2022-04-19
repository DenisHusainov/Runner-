using System;
using TMPro;
using UnityEngine;

public class BonusAndObstalceController : Bonus
{
    public static event Action Crashed = delegate { };

    [SerializeField]
    private TypesOfTrigger _type;
    [SerializeField]
    private TextMeshPro _bonusDoorText = null;
    [SerializeField]
    private BonusAndObstalceController _bonusController = null;
    [SerializeField]
    private int _bonusSpawnNumber = default;
    [SerializeField]
    private PlayerController _player = null;

    private void Start()
    {
        if (_type == TypesOfTrigger.Bonus)
        {
            _bonusDoorText.text = $"{_bonusSpawnNumber}";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            if (_type == TypesOfTrigger.Bonus)
            {
                ((ISpawner)_player).Spawn(_bonusSpawnNumber);
                _bonusController.gameObject.SetActive(false);
            }

            if (_type == TypesOfTrigger.Obstacle)
            {
                Crashed();
            }
        }
    }
}
