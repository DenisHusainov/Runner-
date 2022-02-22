using System;
using UnityEngine;
using UnityEngine.UI;

public class GameWindow : Window
{
    public static event Action Started = delegate { };

    [SerializeField]
    private Canvas _gameWindow;
    [SerializeField]
    private Button _startGameButton;

    private void Start()
    {
        _startGameButton.onClick.AddListener(OnStartGameButtonClicked);
    }

    public override void Show()
    {
        _gameWindow.gameObject.SetActive(true);
    }

    private void OnStartGameButtonClicked()
    {
        Started();
    }
}
