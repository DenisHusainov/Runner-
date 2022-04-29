using TMPro;
using UnityEngine;

public class BonusController : ObjectContact
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

    public override void OnInteracted(PlayerController player)
    {
        ((ISpawner)player).Spawn(_bonusSpawnNumber);
        _bonusController.gameObject.SetActive(false);
    }
}
