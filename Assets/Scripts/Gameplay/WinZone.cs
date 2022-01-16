using System;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;
    
    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponentInParent<Player>();
        if (player)
        {
            _gameManager.Win();
        }
    }
}
