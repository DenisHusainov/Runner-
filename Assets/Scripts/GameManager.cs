using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action Fineshed = delegate { };

    public static GameManager Instance = null;

    public bool IsStarted { get; private set; }
    public bool IsFineshed { get; private set; }

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
        PlayerController.Finish += PlayerController_Finish;
    }

    private void OnDisable()
    {
        GameWindow.Started -= GameWindow_Started;
        PlayerController.Finish -= PlayerController_Finish;
    }

    private void GameWindow_Started()
    {
        IsStarted = true;
    }

    private void PlayerController_Finish()
    {
        IsFineshed = true;
        Fineshed();
    }
}