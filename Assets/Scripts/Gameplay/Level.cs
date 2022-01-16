using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _deathZonePrefab;
    [SerializeField] private BoxCollider _levelCollider;
    [SerializeField] private float _wallCount;
    [SerializeField] private float _deathZoneCount;

    private List<GameObject> _walls = new List<GameObject>();
    private List<GameObject> _deathZones = new List<GameObject>();

    public void Generate()
    {
        for (int i = 0; i < _wallCount; i++)
        {
            _walls.Add(Spawn(_wallPrefab));
        }

        for (int i = 0; i < _deathZoneCount; i++)
        {
            _deathZones.Add(Spawn(_deathZonePrefab));
        }
    }

    public void Clear()
    {
        foreach (var wall in _walls)
        {
            Destroy(wall);
        }

        foreach (var deathZone in _deathZones)
        {
            Destroy(deathZone);
        }
        
        _walls.Clear();
        _deathZones.Clear();
    }

    private GameObject Spawn(GameObject prefab)
    {
        var wall = Instantiate(prefab, GetRandomPos(), Quaternion.identity, transform);
        return wall;
    }

    private Vector3 GetRandomPos()
    {
        var extents = _levelCollider.bounds.extents;
        var circlePos = Random.insideUnitCircle;
        var randomPos = _levelCollider.center + new Vector3(circlePos.x * extents.x, 0, circlePos.y * extents.z);
        return new Vector3(Mathf.Round(randomPos.x) - .5f, 0, Mathf.Round(randomPos.z) - .5f);
    }
}
