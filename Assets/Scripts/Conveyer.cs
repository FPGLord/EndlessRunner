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

   
    
    
    
    
    private Platform[] _platforms;
    private int _backMoveDelta = 9;
    private int _platformsSpawnPositionX = 40;
    private int _speedChangeValue = 10;
    


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

            if (platform.positionX >= _platformsSpawnPositionX)

                ShiftPlatform(platform);
        }
    }

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
        _moveSpeed = 0;
    }

    public void SpeedUp()
    {
        _moveSpeed += _speedChangeValue;
        print($"SpeedUp - Frame {Time.frameCount}");
    }
    
    public void SpeedDown()
    {
        print($"SpeedDown - Frame {Time.frameCount}");
        if (_moveSpeed > _speedChangeValue)
        {
            _moveSpeed -= _speedChangeValue;
        }
    }

}