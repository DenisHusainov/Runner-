using UnityEngine;

public class PlayerController : UIJoystick
{
    private const float _speed = 0.3f;

    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _rb;
    private Vector3 _moveVector;

    private void FixedUpdate()
    {
        _moveVector = PoolInput();
        //_rb.velocity = new Vector3(0,0,_speed);
        transform.position += _moveVector * _speed;
    }

    //private void OnEnable()
    //{
    //    UIJoystick.MovePlayerRight += UIJoystick_MovePlayerRight;
    //    UIJoystick.MovePlayerLeft += UIJoystick_MovePlayerLeft;
    //}

    //private void OnDisable()
    //{
    //    UIJoystick.MovePlayerRight -= UIJoystick_MovePlayerRight;
    //    UIJoystick.MovePlayerLeft -= UIJoystick_MovePlayerLeft;
    //}

    private Vector3 NewVector(float _x, float _turnSpeed)
    {
        return new Vector3(_x * Time.deltaTime * _turnSpeed, 0, 0);
    }

    private void UIJoystick_MovePlayerRight()
    {
        //MoveLeft
    }

    private void UIJoystick_MovePlayerLeft()
    {
        //MoveRight
    }

    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = Horizontal();

        return dir;
    }

    public float Horizontal()
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
