using TMPro;
using UnityEngine;

public class BonusController : Detected
{
    [SerializeField]
    private TextMeshPro _bonusDoorText = null;
    [SerializeField]
    private BonusController _bonusController = null;
    [SerializeField]
    private int _bonusSpawnNumber = default;

    private void Start()
    {
        _bonusDoorText.text = $"{_bonusSpawnNumber}";
    }

    public override void DetectedObject(PlayerController player)
    {
        ((ISpawner)player).Spawn(_bonusSpawnNumber);
        _bonusController.gameObject.SetActive(false);
    }
}
