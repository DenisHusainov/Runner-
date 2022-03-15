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

    private PlayerController _player = null;

    private void Start()
    {
        _bonusDoorText.text = _bonusSpawnNumber.ToString();
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
