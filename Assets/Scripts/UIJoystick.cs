using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField]
    private Image _backgroundJoystick;
    [SerializeField]
    private Image _joystick;

    public static UIJoystick Instance = null;

    public static Vector3 InputVector { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = null;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_backgroundJoystick.rectTransform,eventData.position,eventData.pressEventCamera,out pos))
        {
            pos.x = (pos.x / _backgroundJoystick.rectTransform.sizeDelta.x);

            InputVector = new Vector3(pos.x, 0, 0);
            InputVector = (InputVector.magnitude > 1.0f) ? InputVector.normalized : InputVector;

            _joystick.rectTransform.anchoredPosition = new Vector3(InputVector.x * (_backgroundJoystick.rectTransform.sizeDelta.x / 2), InputVector.z * (_backgroundJoystick.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        InputVector = Vector3.zero;
        _joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
