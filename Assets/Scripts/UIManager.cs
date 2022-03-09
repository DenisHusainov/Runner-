using System.Linq;
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
        var windowToShow = _windows.FirstOrDefault(x => x is T);
        windowToShow.Show();
    }
}