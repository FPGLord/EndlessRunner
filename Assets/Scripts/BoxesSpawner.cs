using UnityEngine;
using UnityEngine.Assertions;

public class BoxesSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _boxPrefabs;

    public void SpawnBoxes()
    {
        Assert.IsTrue(_boxPrefabs.Length <= _spawnPoints.Length,
            $" Коробок ({_boxPrefabs.Length})  больше, чем поинтов ({_spawnPoints.Length}) ");
        ShuffleSpawnPoints();
        for (int i = 0; i < _boxPrefabs.Length; i++)
        {
            _boxPrefabs[i].transform.position = _spawnPoints[i].position;
            _boxPrefabs[i].SetActive(true);
        }
    }

    private void ShuffleSpawnPoints()
    {
        for (int i = 0; i < _boxPrefabs.Length; i++)
        {
            int randomPointIndex = Random.Range(0, _spawnPoints.Length);
            (_spawnPoints[i], _spawnPoints[randomPointIndex]) = (_spawnPoints[randomPointIndex], _spawnPoints[i]);
        }
    }
}