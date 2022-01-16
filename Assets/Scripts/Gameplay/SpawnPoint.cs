using System.Collections;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private GameObject _playerPrefab;

    private Player _player;
    
    private void Awake()
    {
        _player = Instantiate(_playerPrefab, transform.position, Quaternion.identity).GetComponent<Player>();
        _player.Died += () => StartCoroutine(OnDied());
    }

    private IEnumerator OnDied()
    {
        yield return new WaitForEndOfFrame();
        Respawn();
    }

    public void Respawn()
    {
        _player.Respawn(transform.position);
    }
}
