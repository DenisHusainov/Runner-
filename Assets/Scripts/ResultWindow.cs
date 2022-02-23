using UnityEngine;

public class ResultWindow : Window
{
    [SerializeField]
    private Canvas _resultWindow;

    public override void Show()
    {
        _resultWindow.gameObject.SetActive(true);
    }
}
