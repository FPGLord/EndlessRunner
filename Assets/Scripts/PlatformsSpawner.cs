using UnityEngine;
using UnityEngine.Serialization;


public class PlatformsSpawner : MonoBehaviour
{
    [SerializeField] private Transform _currentPlatform;
    [SerializeField] private GameObject _platformPrefab;
    [SerializeField] private int _platformsAmount;

    private GameObject[] _platforms;

    private void Start()
    {
        PoolerPlatforms();
    }

    private void Update()
    {
        if (_currentPlatform.position.x >= 0)
            SpawnPlatform();
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
        //GameObject temp;
       // Последнюю слева платформу и переместить ее крайнее правое положение справа
            _platforms[0].transform.position =
                new Vector3(
                    _platforms[^1].transform.position.x -
                    _platforms[^1].transform.localScale.x, 0, 0);
          
         
           _platforms[0] = _platforms[1];

        var temp = _platforms[0];
        _platforms[0] = _platforms[^1];
        _platforms[^1] = temp;
        _currentPlatform = temp.transform;
    }
}
//     //_platforms[1].transform.position = new Vector3(_currentPlatform.position.x,0,0);
// Array.ForEach(_platforms,PlatformCount);
//Debug.Break();

// private void PlatformCount(GameObject obj)
// {
//     for (int i = 0; i < _platforms.Length; i++)
//     {
//     _platforms[i].transform.position = new Vector3(-_currentPlatform.localScale.x+2,0,0);
//     _currentPlatform = _platforms[i].transform;
//         
//     }
// }


// private void SpawnPlatform()
// {
//     GameObject newPlatform = Instantiate(_platformPrefab,
//         new Vector3(_currentPlatform.position.x - _currentPlatform.localScale.x, _currentPlatform.position.y,
//             _currentPlatform.position.z), _currentPlatform.rotation);
//     _currentPlatform = newPlatform.transform;
//     Debug.Log("Spawn");
//     //Debug.Break();
// }