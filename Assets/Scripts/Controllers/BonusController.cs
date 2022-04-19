using System;
using TMPro;
using UnityEngine;

public class BonusController : Detected
{
    [SerializeField]
    private TypesOfTrigger _type;
    [SerializeField]
    private TextMeshPro _bonusDoorText = null;
    [SerializeField]
    private BonusController _bonusController = null;
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

    public override void DetectedObject()
    {    
        ((ISpawner)_player).Spawn(_bonusSpawnNumber);
        _bonusController.gameObject.SetActive(false);
    }
}
