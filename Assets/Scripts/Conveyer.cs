using UnityEngine;

public class Conveyer : MonoBehaviour
{
    // [SerializeField] private Transform _currentPlatform;
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private int _platformsAmount;
    [SerializeField] private float _moveSpeed;
    private Platform[] _platforms;

    private void Start()
    {
        CreatePlatforms();
    }

    private void Update()
    {
        MovePlatforms();
    }

    private void MovePlatforms()
    {
        foreach (var platform in _platforms)
        {
            platform.Move(Vector2.right, _moveSpeed * Time.deltaTime);

            if (platform.positionX >= 40)
            
                ShiftPlatform(platform);
            
        }
    }

    private void CreatePlatforms()
    {
        _platforms = new Platform[_platformsAmount];
        for (int i = 0; i < _platformsAmount; i++)
        {
            Platform newPlatform = Instantiate(_platformPrefab,
                new Vector3(_platformPrefab.positionX - _platformPrefab.length, 0, 0), Quaternion.identity);
            _platformPrefab = newPlatform;
            _platforms[i] = newPlatform;
            _platforms[i].Initialize();
        }
        
    }

    private void ShiftPlatform(Platform platform)
    {
        float conveyerLength = platform.length * _platformsAmount;
        platform.Move(Vector2.left, conveyerLength);
        platform.Initialize();
    }
}