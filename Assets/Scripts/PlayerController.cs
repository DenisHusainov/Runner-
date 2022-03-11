using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float Speed = 20f;
    private const float RightBorder = 3.5f;
    private const float LeftBorder = -3.5f;

    [SerializeField]
    private Rigidbody _rb = null;

    private Vector3 _moveVector = default;
    private Vector3 _defaultSpeed = default;
    private int _countPlayers = default;

    private void OnEnable()
    {
        BonusController.Spawed += BonusController_Spawed;
    }

    private void Start()
    {
        _defaultSpeed = new Vector3(0, 0, 1);
    }

    private void FixedUpdate()
    {
        _moveVector = GetMoveVector();
        _rb.velocity = _defaultSpeed * Speed;
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, LeftBorder, RightBorder), transform.position.y, transform.position.z);
        transform.position += _moveVector;
    }

    private Vector3 GetMoveVector()
    {
        Vector3 dir = Vector3.zero;

        dir.x = HorizontalMove();

        return dir;
    }

    public float HorizontalMove()
    {
          return UIJoystick.Instance.InputVector.x;
    }

    private void SpawnerPlayers(int CountPlayers)
    {
        for (int i = 0; i < CountPlayers; i++)
        {
            GameObject spawner = PoolController.Instance.GetPoolObject(PoolType.Player);
            spawner.transform.position = transform.position + new Vector3(0, 2, 0);
            spawner.SetActive(true);
        }
    }

    private void BonusController_Spawed()
    {
        Debug.Log("2");
        SpawnerPlayers(_countPlayers);
    }
}
