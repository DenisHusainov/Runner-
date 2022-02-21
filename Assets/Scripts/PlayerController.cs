using UnityEngine;

public class PlayerController : UIJoystick
{
    private const float TurnSpeed = 0.3f;
    private const float Speed = 20f;

    [SerializeField] private Rigidbody _rb;

    private Vector3 _moveVector;

    private void FixedUpdate()
    {
        _moveVector = PoolInput();
        _rb.velocity = new Vector3(0,0,Speed);
        transform.position += _moveVector * TurnSpeed;
    }

    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = HorizontalMove();

        return dir;
    }

    public float HorizontalMove()
    {
        if (UIJoystick._inputVector.x != 0)
        {
            return UIJoystick._inputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }
}
