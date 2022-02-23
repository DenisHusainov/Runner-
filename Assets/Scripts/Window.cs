using UnityEngine;

public abstract class Window : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
    }
}
