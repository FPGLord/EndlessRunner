using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class Conveyer : MonoBehaviour
{
    [SerializeField] private Platform _platformPrefab;
    [SerializeField] private int _platformsAmount;
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _OnCollisionObstacle;
    [SerializeField] private UnityEvent _OnDeathInvoke;
    
    private Platform[] _platforms;
    private int _backMoveDelta = 9;
    private int _platformsSpawnPositionX = 40;
    private int _speedChangeValue = 10;
    
    public float moveSpeed;
    
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
            platform.Move(Vector2.right, moveSpeed * Time.deltaTime);

            if (platform.positionX >= _platformsSpawnPositionX)

                ShiftPlatform(platform);
        }
    }

    [ContextMenu("Create Platforms")]
    private void CreatePlatforms()
    {
        _platforms = new Platform[_platformsAmount];

        for (int i = 0; i < _platformsAmount; i++)
        {
            Platform newPlatform = Instantiate(_platformPrefab);
            newPlatform.transform.position = new Vector3(_platformPrefab.positionX + i * _platformPrefab.length, 0, 0);
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
            _OnCollisionObstacle.Invoke();
        }
    }
    public void ConveyerStop()
    {
        _OnDeathInvoke.Invoke();
        moveSpeed = 0;
    }

    public void SpeedUp()
    {
        moveSpeed += _speedChangeValue;
    }
    
    public void SpeedDown()
    {
        if (moveSpeed > _speedChangeValue)
        {
            moveSpeed -= _speedChangeValue;
        }
    }

}