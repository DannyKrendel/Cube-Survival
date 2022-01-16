using System;
using System.Collections;
using UnityEngine;

public class LoadingScreen : MonoBehaviour, IScreen
{
    [SerializeField] private GameObject _background;
    [SerializeField] private Fader _fader;
    [SerializeField] private GameManager _gameManager;

    private void Awake()
    {
        _gameManager.GameWon += () => StartCoroutine(ShowCoroutine());
    }

    private IEnumerator ShowCoroutine()
    {
        yield return new WaitForSeconds(_gameManager.GameRestartDelay);
        Show();
    }

    public void Show()
    {
        _background.gameObject.SetActive(true);
        _fader.FadeIn(() =>
        {
            _gameManager.Restart();
            Hide();
        });
    }

    public void Hide()
    {
        _fader.FadeOut(OnHideComplete);
    }

    private void OnHideComplete()
    {
        _background.gameObject.SetActive(false);
    }
}
