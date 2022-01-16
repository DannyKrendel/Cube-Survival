using UnityEngine;
using UnityEngine.UI;

public class ResumeButton : MonoBehaviour
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
        _pauseScreen.Hide();
        _gameManager.TogglePause(false);
    }
}
