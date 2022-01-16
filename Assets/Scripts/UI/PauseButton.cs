using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameManager _gameManager;
    [SerializeField] private PauseScreen _pauseScreen;
    
    private void Awake()
    {
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        _pauseScreen.Show();
        _gameManager.TogglePause(true);
    }
}
