using UnityEngine;

public class Conveyer : MonoBehaviour
{
    [SerializeField] private Transform _currentPlatform;
    [SerializeField] private int _platformsAmount;
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private float _moveSpeed;

    private Platform[] _platforms;

    private void Start()
    {
        CreatePlatforms();
    }

    private void Update()
    {
        MovePlatforms();
        ShiftPlatform();
    }

    private void MovePlatforms()
    {
        foreach (var platform in _platforms)
            platform.Move(Vector2.right * _moveSpeed * Time.deltaTime);
    }

    private void CreatePlatforms()
    {
        //_platforms = new GameObject[_platformsAmount];
        for (int i = 0; i < _platformsAmount; i++)
        {
            Platform newPlatform = Instantiate(_platformPrefab, new Vector3(
                _currentPlatform.position.x - _currentPlatform.localScale.x, _currentPlatform.position.y,
                _currentPlatform.position.z), _currentPlatform.rotation);
            _currentPlatform = newPlatform.transform;
           _platforms[i] = newPlatform;
        }
    }

    private void ShiftPlatform()
    {
        foreach (var platform in _platforms)
        {
            if (platform.transform.position.x >= 0)
                platform.transform.position = new Vector3(platform.transform.localScale.x * _platformsAmount, 0, 0);
        }
    }
}


// var rightPlatform = _platforms[^1];
// var leftPlatform = _platforms[0];
// var nextPosition = new Vector3(
//     rightPlatform.transform.position.x -
//     rightPlatform.transform.localScale.x, 0, 0);
//
//
// if (index == _platformsAmount)
// {
//     index = 0;
//     leftPlatform = _platforms[index];
// }
//
// rightPlatform = leftPlatform;
// leftPlatform.transform.position =
//     nextPosition;
// _currentPlatform = rightPlatform.transform;
//
// if (_currentPlatform.position.x >= 0)
// {
//     leftPlatform = _platforms[index];
//     _currentPlatform = leftPlatform.transform;
//     leftPlatform.transform.position =
//         new Vector3(_currentPlatform.transform.position.x - _currentPlatform.transform.localScale.x, 0, 0);
// }