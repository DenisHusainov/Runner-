using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action Started = delegate { };
    public static event Action Fineshed = delegate { };

    public static GameManager Instance;

    public static bool IsFineshed { get; private set; }

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (UIManager.IsStarted)
        {
            Started();
        }
    }
}