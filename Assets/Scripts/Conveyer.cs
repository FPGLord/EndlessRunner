using UnityEngine;
using UnityEngine.Events;

public class Conveyer : MonoBehaviour
{
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private int _platformsAmount;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _OnCollisionObstacle;
    [SerializeField] private UnityEvent _OnDeathInvoke;
    [SerializeField] private int _platformValueToSpawnBox;
    
    
    private Platform[] _platforms;
    private float _animationSpeed = 0.5f;
    private int _backMoveDelta = 9;
    private int _platformsSpawnPositionX = 40;
    private int _speedChangeValue = 10;
    private int _countShiftPlatforms;

    private void Start()
    {
        CreatePlatforms();
    }

    private void Update()
    {
        MovePlatforms();
        SpawnBoxes();
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

    void SpawnBoxes()
    {
        if (_countShiftPlatforms == _platformValueToSpawnBox)
        {
            for (int i = 0; i < _platforms.Length; i++)
                _platforms[^1].InitializeBoxes();
            _countShiftPlatforms = 0;
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
        _countShiftPlatforms++;
    }

    public void MoveBack()
    {
        foreach (var platform in _platforms)
        {
            platform.Move(Vector2.left, _backMoveDelta);
            _OnCollisionObstacle.Invoke();
        }
    }

    public void SpeedUp()
    {
        _moveSpeed += _speedChangeValue;
        _animator.speed += _animationSpeed;
    }

    public void SpeedDown()
    {
        if (_moveSpeed > _speedChangeValue)
        {
            _moveSpeed -= _speedChangeValue;
            _animator.speed -= _animationSpeed;
        }
    }

    public void ConveyerStop()
    {
        _OnDeathInvoke.Invoke();
        _moveSpeed = 0;
    }
}