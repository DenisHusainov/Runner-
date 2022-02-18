using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWindow : Window
{
    public static event Action Started = delegate { };

    [SerializeField] private Canvas _gameWindow;
    [SerializeField] private Button _startGame;

    private void Start()
    {
        _startGame.onClick.AddListener(GameStarted);
        _startGame.gameObject.SetActive(false);
    }


    public override void Show()
    {
        _gameWindow.gameObject.SetActive(true);
    }

    private void GameStarted()
    {
        Started();
    }
}
