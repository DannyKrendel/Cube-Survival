using UnityEngine;

public class PlayerEffects : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Renderer _renderer;
    [SerializeField] private ParticleSystem _deathParticles;
    [SerializeField] private ParticleSystem _winParticles;
    [SerializeField] private Color _shieldColor;

    private GameManager _gameManager;
    private Color _normalColor;
    
    private void Awake()
    {
        _normalColor = _renderer.material.color;
        var main = _deathParticles.main;
        main.startColor = _renderer.material.color;
        _player.Died += OnDied;
        _player.ShieldActivated += OnShieldActivated;
        _player.ShieldDeactivated += OnShieldDeactivated;
        _gameManager = FindObjectOfType<GameManager>();
        if (_gameManager)
            _gameManager.GameWon += OnGameWon;
    }

    private void OnDied()
    {
        _deathParticles.Play();
    }

    private void OnGameWon()
    {
        _winParticles.Play();
    }

    private void OnShieldActivated()
    {
        _renderer.material.color = _shieldColor;
    }

    private void OnShieldDeactivated()
    {
        _renderer.material.color = _normalColor;
    }
}
