using UnityEngine;

public class Conveyer : MonoBehaviour
{
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private int _platformsAmount;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private ConveyerVariable _conveyerVariable;
    [SerializeField]private SpeedBoxes _speedBoxes;
    private Platform[] _platforms;

    private int _backMoveDelta = 4;
    int _platformsSpawnPositionX = 40;
    private int _speedChangeValue = 10;

    private void Start()
    {
        _conveyerVariable.Set(this);
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

            if (platform.positionX >= _platformsSpawnPositionX)

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
//        _speedBoxes.CreateBoxes();
    }

    public void MoveBack()
    {
        foreach (var platform in _platforms)
        {
            platform.Move(Vector2.left, _backMoveDelta);
        }
    }

    public void SpeedUp()
    {
        _moveSpeed += _speedChangeValue;
    }

    public void SpeedDown()
    {
        if (_moveSpeed > _speedChangeValue)
            _moveSpeed -= _speedChangeValue;
    }
}