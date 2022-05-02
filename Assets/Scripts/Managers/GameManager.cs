using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action Finished = delegate { };

    public static GameManager Instance { get; private set; }
    public bool IsStarted { get; private set; }
    public bool IsFinished { get; private set; }

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
        MainWindow.Started += MainWindow_Started;
        FinishController.Won += PlayerController_Won;
    }

    private void OnDisable()
    {
        MainWindow.Started -= MainWindow_Started;
        FinishController.Won -= PlayerController_Won;
    }

    private void MainWindow_Started()
    {
        IsStarted = true;
    }

    private void PlayerController_Won()
    {
        IsFinished = true;
        Finished();
    }
}