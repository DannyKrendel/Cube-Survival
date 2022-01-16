using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShieldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _fillImage;
    [SerializeField, Range(0, 5)] private float _holdTime = 2;

    private Player _player;
    private bool _isPointerDown;
    private float _pointerDownTimer;

    private IEnumerator Start()
    {
        enabled = false;
        yield return new WaitUntil(() =>
        {
            _player = FindObjectOfType<Player>();
            return _player;
        });
        enabled = true;
    }
    
    private void Update()
    {
        if (!_isPointerDown) return;
        
        _pointerDownTimer += Time.deltaTime;

        _fillImage.fillAmount = 1 - _pointerDownTimer / _holdTime;
        
        if (_pointerDownTimer >= _holdTime)
            ResetState();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPointerDown = true;
        _player.ActivateShield();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPointerDown = false;
        ResetState();
        ResetFill();
    }

    private void ResetState()
    {
        _player.DeactivateShield();
        _isPointerDown = false;
        _pointerDownTimer = 0;
    }

    private void ResetFill()
    {
        _fillImage.fillAmount = 1;
    }
}
