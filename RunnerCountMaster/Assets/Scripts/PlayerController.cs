using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IBeginDragHandler, IDragHandler, IMoveHandler
{ 
    [SerializeField] private float _speed;
    [SerializeField] private Transform _player;
    [SerializeField] private Rigidbody _rb;

    private void FixedUpdate()
    {
        //_rb.velocity = new Vector3(0,0,_speed);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            if (eventData.delta.x > 0)
            {
                //transform.Translate(Vector3.right);
                _player.position += new Vector3(delta.x * _speed, 0, 0);
                Debug.Log("Right");
            }
            else
            {
                Debug.Log("Left");
            }
        }
        
    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnMove(AxisEventData eventData)
    {
       
    }
}
