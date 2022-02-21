using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action Fineshed = delegate { };

    public static GameManager Instance = null;

    public static bool IsStarted { get; private set; }
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

    private void OnEnable()
    {
        GameWindow.Started += GameWindow_Started;
    }

    private void OnDisable()
    {
        GameWindow.Started -= GameWindow_Started;
    }

    private void GameWindow_Started()
    {
        IsStarted = true;
    }
}