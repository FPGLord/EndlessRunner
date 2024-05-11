using UnityEngine;
using UnityEngine.Assertions;

public class Platform : MonoBehaviour
{
    [SerializeField] private CoinsSpawner _coinsSpawner;
    [SerializeField] private Spawner<PowerUpBox> _boxesSpawner;
    [SerializeField] private Transform _visualTransform;
    [SerializeField] private Spawner<GameObject>[] _gameObjectsSpawner;

    public float positionX => transform.position.x;
    public float length => _visualTransform.localScale.x;

    public void Move(Vector2 direction, float moveDelta)
    {
        Assert.IsTrue(direction == direction.normalized, $"Vector is not normalized {direction} ");
        transform.Translate(direction * moveDelta);
    }

    public void Initialize()
    {
        foreach (var items in _gameObjectsSpawner)
        {
            items.Spawn();
        }

        _boxesSpawner.Spawn();
        _coinsSpawner.SpawnCoins();
    }
}