using UnityEngine;

public class Conveyer : MonoBehaviour
{
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private int _platformsAmount;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private ConveyerVariable _conveyerVariable;
    private SpeedUpBox _speedUpBox;
    private Platform[] _platforms;

    private int _backMoveDelta = 4;
    int platformsSpawnPositionX = 40;

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

            if (platform.positionX >= platformsSpawnPositionX)

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

    public void MoveBack()
    {
        foreach (var platform in _platforms)
        {
            platform.Move(Vector2.left, _backMoveDelta);
        }
    }

    public void SpeedUp()
    {
        _moveSpeed += 10;
            //  _speedUpBox.Disable();
    }

    public void SpeedDown()
    {
        if (_moveSpeed > 10)
            _moveSpeed -= 10;
    }
}