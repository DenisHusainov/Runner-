using TMPro;
using UnityEngine;

public class BonusController : MonoBehaviour
{
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
        _bonusDoorText.text = $"{_bonusSpawnNumber}";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            _player.Spawn(_bonusSpawnNumber);
            _bonusController.gameObject.SetActive(false);
        }
    }
}
