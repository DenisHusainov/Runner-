using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void ShowWindow<T>() where T : Window
    {
        T window = GetComponentInChildren<T>();
        window.Show();
    }
}
