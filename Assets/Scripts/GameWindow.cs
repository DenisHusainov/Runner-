using System;
using UnityEngine;
using UnityEngine.UI;

public class GameWindow : Window
{
    public static event Action Started = delegate { };

    [SerializeField]
    private Button _startGameButton;

    private Canvas _gameWindow = null;

    private void Start()
    {
        _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
    }

    private void OnStartGameButtonClicked()
    {
        Started();
    }
}
