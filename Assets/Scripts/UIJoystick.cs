using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIJoystick : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public static event Action MovePlayerRight = delegate { };
    public static event Action MovePlayerLeft = delegate { };

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 delta = eventData.delta;

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
        {
            if (eventData.delta.x > 0)
            {
                MovePlayerRight();
                Debug.Log("Right");
            }
            else
            {
                MovePlayerLeft();
                Debug.Log("Left");
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {

    }
}
