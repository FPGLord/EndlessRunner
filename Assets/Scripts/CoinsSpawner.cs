using UnityEngine;
using Random = System.Random;


public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnCoinsPoints;

    private int _coinsAmount;
    private GameObject[] _coins;
    private Random rnd = new Random();
    private int _coinsStep = 2;

    private void Start()
    {
        CoinsPooler();
    }

    private void CoinsPooler()
    {
        _coinsAmount = rnd.Next(1, 20);
        _coins = new GameObject[_coinsAmount];

        for (int i = 0; i < _coins.Length; i++)
        {
            int randomPointIndex = rnd.Next(0, 3);
            Vector3 spawnPosition = _spawnCoinsPoints[randomPointIndex].position;
            spawnPosition.x += i * _coinsStep;
            GameObject newCoins = Instantiate(_coinPrefab, spawnPosition, Quaternion.identity);
            _coins[i] = newCoins;
        }
    }

    private void CoinSpawner()
    {
        foreach (var item in _coins)
        {
            Debug.Log(item);
        }
    }
}