using UnityEngine;

public class PlayerController : UIJoystick
{
    private const float TurnSpeed = 20f;
    private const float Speed = 20f;

    [SerializeField]
    private Rigidbody _rb;

    private Vector3 _moveVector;
    private Vector3 _defaultSpeed;

    private void Start()
    {
        _defaultSpeed = new Vector3(0, 0, Speed);// тут не работает
    }

    private void FixedUpdate()
    {
        _moveVector = PoolInput();
        _rb.velocity = _defaultSpeed;
        _rb.velocity = _moveVector * TurnSpeed;
    }

    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = HorizontalMove();

        return dir;
    }

    public float HorizontalMove()
    {
        if (UIJoystick.InputVector.x != 0)
        {
            return UIJoystick.InputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
}
