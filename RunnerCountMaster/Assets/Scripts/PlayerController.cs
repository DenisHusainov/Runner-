using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour, IBeginDragHandler, IDragHandler
{ 
    [SerializeField] private float _speed;
    [SerializeField] private Transform _player;

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            if (eventData.delta.x > 0)
            {
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
}
