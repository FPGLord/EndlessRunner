using System.Collections.Generic;
using UnityEngine;

public class Spawner<TData> : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private TData[] _data;
    [SerializeField] private View<TData> _viewPrefab;

    private List<View<TData>> _spawnedViews = new();

    public void Spawn()
    {
        foreach (var item in _spawnedViews)
        {
            item.Deactivate();
        }

        for (int i = 0; i < _data.Length; i++)
        {
            if (_spawnedViews.Count <= i)
            {
                View<TData> newView = Instantiate(_viewPrefab, transform);
                _spawnedViews.Add(newView);
            }

            _spawnedViews[i].ViewData(_data[i]);
        }

        ShuffleSpawnObstacles();
        SpawnObstacles();
    }

    private void SpawnObstacles()
    {
        if (_spawnPoints.Length > _spawnedViews.Count)
        {
            ShuffleSpawnPoints();
            for (int j = 0; j < _spawnedViews.Count; j++)
            {
                _spawnedViews[j].transform.position = _spawnPoints[j].position;
                _spawnedViews[j].Activate();
            }
        }
        else
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                _spawnedViews[i].transform.position = _spawnPoints[i].position;
                _spawnedViews[i].Activate();
            }
        }
    }

    private void ShuffleSpawnObstacles()
    {
        for (int i = 0; i < _spawnedViews.Count; i++)
        {
            int randomObstacleIndex = Random.Range(0, _spawnedViews.Count);
            (_spawnedViews[i], _spawnedViews[randomObstacleIndex]) =
                (_spawnedViews[randomObstacleIndex], _spawnedViews[i]);
        }
    }
    
    private void ShuffleSpawnPoints()
    {
        for (int i = 0; i < _spawnPoints.Length; i++)
        {
            int randomObstacleIndex = Random.Range(0, _spawnPoints.Length);
            (_spawnPoints[i], _spawnPoints[randomObstacleIndex]) =
                (_spawnPoints[randomObstacleIndex], _spawnPoints[i]);
        }
    }
}