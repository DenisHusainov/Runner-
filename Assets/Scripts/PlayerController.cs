using System;
using UnityEngine;

public class PlayerController : UIJoystick
{
    public static event Action Won = delegate { };

    private const float Speed = 20f;

    [SerializeField]
    private Rigidbody _rb;

    private Vector3 _moveVector = default;
    private Vector3 _defaultSpeed = default;

    private void Start()
    {
        _defaultSpeed = new Vector3(0, 0, 1);
    }

    private void FixedUpdate()
    {
        _moveVector = PoolInput();
        _rb.velocity = _defaultSpeed * Speed;
        transform.position += _moveVector;
    }

    private Vector3 PoolInput()
    {
        Vector3 dir = Vector3.zero;

        dir.x = HorizontalMove();

        return dir;
    }

    public float HorizontalMove()
    {
        if (InputVector.x != 0)
        {
            return InputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BoxCollider>())
        {
            Won();
        }
    }
}
