using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _gameRestartDelay = 1;
    [SerializeField] private Level _level;
    [SerializeField] private SpawnPoint _spawnPoint;
    
    public float GameRestartDelay => _gameRestartDelay;

    public event Action GameWon;

    public bool IsPaused { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        _level.Generate();
    }

    public void TogglePause(bool value)
    {
        Time.timeScale = value ? 0 : 1;
        IsPaused = value;
    }

    public void Restart()
    {
        _level.Clear();
        _level.Generate();
        _spawnPoint.Respawn();
    }

    public void Win()
    {
        GameWon?.Invoke();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
