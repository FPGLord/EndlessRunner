using System.Collections.Generic;
using UnityEngine;


public class BoxesSpawner : MonoBehaviour
{
    // [SerializeField] private Transform _platform;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _boxes;


    public void SpawnBoxes()
    {
        List<int> usedPointIndexes = new();
        int randomPointIndex = 0;
        
        foreach (var box in _boxes)
        {
            do
            {
                randomPointIndex = Random.Range(0, _spawnPoints.Length);
            } 
            while (usedPointIndexes.Contains(randomPointIndex));

            Vector3 _spawnPointPosition = _spawnPoints[randomPointIndex].position;
            box.transform.position = _spawnPointPosition;
            box.SetActive(true);
            usedPointIndexes.Add(randomPointIndex);
        }
    }
}