using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IBeginDragHandler, IDragHandler
{ 
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (eventData.delta.x>0)
        {
            _rigidbody.AddForce(Vector3.right * _speed, ForceMode.Force);
        }
        else
        {
            _rigidbody.AddForce(Vector3.left * _speed, ForceMode.Force);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
