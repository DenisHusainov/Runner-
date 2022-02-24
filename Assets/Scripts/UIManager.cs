using UnityEngine;

public class UIManager : MonoBehaviour
{
    private Window[] _windows;
    private void Awake()
    {
        _windows = GetComponentsInChildren<Window>();
        DontDestroyOnLoad(gameObject);
    }

    public void ShowWindow<T>() where T : Window
    {
        foreach (var window in _windows)
        {
            if (window is T)
            {
                window.Show();
            }
        }
    }
}