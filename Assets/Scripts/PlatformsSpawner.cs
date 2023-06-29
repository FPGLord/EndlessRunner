using System;
using UnityEngine;
using UnityEngine.Serialization;


public class PlatformsSpawner : MonoBehaviour
{
    [SerializeField] private Transform _currentPlatform;
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private int _platformsAmount;

    private GameObject[] _platforms;
    private int index = 0;

    private void Start()
    {
        PoolerPlatforms();
    }

    private void Update()
    {
        if (_currentPlatform.position.x >= 0)
        {
            SpawnPlatform();
            index++;
        }
    }

    private void PoolerPlatforms()
    {
        _platforms = new GameObject[_platformsAmount];
        for (int i = 0; i < _platformsAmount; i++)
        {
            GameObject newPlatform = Instantiate(_platformPrefab, new Vector3(
                _currentPlatform.position.x - _currentPlatform.localScale.x, _currentPlatform.position.y,
                _currentPlatform.position.z), _currentPlatform.rotation);
            _currentPlatform = newPlatform.transform;
            _platforms[i] = newPlatform;
        }
    }

    private void SpawnPlatform()
    {
        var rightPlatform = _platforms[^1];
        var leftPlatform = _platforms[0];
        var nextPosition = new Vector3(
            rightPlatform.transform.position.x -
            rightPlatform.transform.localScale.x, 0, 0);


        if (index == _platformsAmount)
        {
            index = 0;
            leftPlatform = _platforms[index];
        }

        rightPlatform = leftPlatform;
        leftPlatform.transform.position =
            nextPosition;
        _currentPlatform = rightPlatform.transform;

        if (_currentPlatform.position.x >= 0)
        {
            leftPlatform = _platforms[index];
            _currentPlatform = leftPlatform.transform;
            leftPlatform.transform.position =
                new Vector3(_currentPlatform.transform.position.x - _currentPlatform.transform.localScale.x, 0, 0);
        }
    }
}