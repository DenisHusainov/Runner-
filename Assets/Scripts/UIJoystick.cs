using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private Image _backgroundJoystick;
    [SerializeField] private Image _joystick;

    public static Vector3 _inputVector { get; private set; }

    public static UIJoystick Instance = null;

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
            //pos.y = (pos.y / _backgroundJoystick.rectTransform.sizeDelta.y);

            _inputVector = new Vector3(pos.x * 2 + 1, 0, 0);
            _inputVector = (_inputVector.magnitude > 1.0f) ? _inputVector.normalized : _inputVector;

            _joystick.rectTransform.anchoredPosition = new Vector3(_inputVector.x * (_backgroundJoystick.rectTransform.sizeDelta.x / 2), _inputVector.z * (_backgroundJoystick.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputVector = Vector3.zero;
        _joystick.rectTransform.anchoredPosition = Vector3.zero;
    }
}
