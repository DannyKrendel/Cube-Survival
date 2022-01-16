using System;
using DG.Tweening;
using UnityEngine;

public class Fader : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField, Range(0, 5)] private float _fadeInDuration = 1;
    [SerializeField, Range(0, 5)] private float _fadeOutDuration = 1;

    public float FadeInDuration => _fadeInDuration;
    public float FadeOutDuration => _fadeOutDuration;

    private void Awake()
    {
        _canvasGroup.alpha = 0;
    }

    public void FadeIn(Action onComplete = null)
    {
        _canvasGroup.DOFade(1, _fadeInDuration).OnComplete(() => onComplete?.Invoke());
    }
    
    public void FadeOut(Action onComplete = null)
    {
        _canvasGroup.DOFade(0, _fadeOutDuration).OnComplete(() => onComplete?.Invoke());
    }
}
