using UnityEngine;

public class UIManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static void ShowWindow<T>() where T : Window
    {
        T window = FindObjectOfType<T>();
        window.Show();
    }
}
