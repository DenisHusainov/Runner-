using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField] private float _speed;
    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _rb;

    private void FixedUpdate()
    {
        _rb.velocity = new Vector3(0,0,_speed);
    }

    private void OnEnable()
    {
        UIJoystick.MovePlayerRight += UIJoystick_MovePlayerRight;
        UIJoystick.MovePlayerLeft += UIJoystick_MovePlayerLeft;
    }

    private void OnDisable()
    {
        UIJoystick.MovePlayerRight -= UIJoystick_MovePlayerRight;
        UIJoystick.MovePlayerLeft -= UIJoystick_MovePlayerLeft;
    }

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
}
