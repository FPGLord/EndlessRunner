using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Spawner<TData> : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private TData[] _data;
    [SerializeField] private View<TData> _viewPrefab;

    private List<View<TData>> _spawnedViews = new();

    public void Spawn()
    {
        foreach (var item in _spawnedViews)
            item.Deactivate();

        for (int i = 0; i < _data.Length; i++)
        {
            if (_spawnedViews.Count <= i)
            {
                View<TData> newPowerUpBoxView = Instantiate(_viewPrefab, transform);
                _spawnedViews.Add(newPowerUpBoxView);
            }
            _spawnedViews[i].ViewData(_data[i]);
        }

        Assert.IsTrue(_spawnedViews.Count <= _spawnPoints.Length,
            $" Коробок ({_spawnedViews.Count})  больше, чем поинтов ({_spawnPoints.Length}) ");

        ShuffleSpawnPoints();

        for (int i = 0; i < _spawnedViews.Count; i++)
        {
            _spawnedViews[i].transform.position = _spawnPoints[i].position;
            _spawnedViews[i].Activate();
        }
    }

    private void ShuffleSpawnPoints()
    {
        int randomPointIndex = Random.Range(0, _spawnPoints.Length);
        (_spawnPoints[0], _spawnPoints[randomPointIndex]) = (_spawnPoints[randomPointIndex], _spawnPoints[0]);
    }
}