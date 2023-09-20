using UnityEngine;
using UnityEngine.Assertions;


public class Platform : MonoBehaviour
{
    [SerializeField] private CoinsSpawner _coinsSpawner;
    [SerializeField] private BoxesSpawner _boxesSpawner;


    public float positionX => transform.position.x;
    public float length => transform.localScale.x;

    public void Move(Vector2 direction, float moveDelta)
    {
        Assert.IsTrue(direction == direction.normalized, $"Vector is not normalized {direction} ");
        transform.Translate(direction * moveDelta);
    }

    public void Initialize()
    {
        _coinsSpawner.SpawnCoins();
        _boxesSpawner.SpawnBoxes();
    }
}