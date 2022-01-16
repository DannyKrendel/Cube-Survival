using UnityEngine;

public class PauseScreen : MonoBehaviour, IScreen
{
    [SerializeField] private Fader _fader;

    public void Show()
    {
        gameObject.SetActive(true);
        _fader.FadeIn();
    }

    public void Hide()
    {
        _fader.FadeOut(OnHideComplete);
    }

    private void OnHideComplete()
    {
        gameObject.SetActive(false);
    }
}
