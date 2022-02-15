using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static bool IsStarted { get; private set; }

    [SerializeField] private Button _buttonStart;

    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("UI");

        if (objs.Length > 1)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        _buttonStart.onClick.AddListener(StartGame);
    }

    private void StartGame()
    { 
        IsStarted = true;
    }
}
