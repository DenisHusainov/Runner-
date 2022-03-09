using UnityEngine;

public abstract class Window : MonoBehaviour
{
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
}
