using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const float Speed = 20f;

    [SerializeField]
    private Rigidbody _rb = null;

    private Vector3 _moveVector = default;
    private Vector3 _defaultSpeed = default;

    private void Start()
    {
        _defaultSpeed = new Vector3(0, 0, 1);
    }

    private void FixedUpdate()
    {
        _moveVector = GetMoveVector();
        _rb.velocity = _defaultSpeed * Speed;
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
}
