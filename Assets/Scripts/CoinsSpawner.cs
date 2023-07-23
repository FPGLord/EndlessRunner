using UnityEngine;
using Random = System.Random;


public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnCoinsPoints;
    [SerializeField] private Transform _platform;
    [SerializeField] private int _coinsAmount; // Общее количество монет для спавна
    
    private GameObject[] _coins;
    private Random _rnd = new Random();
    private int _coinsStep = 2;
   

    private void Start()
    {
        CreateCoins();
        SpawnCoins();
    }
    private void CreateCoins()
    {
        _coins = new GameObject[_coinsAmount];

        for (int i = 0; i < _coinsAmount; i++)
        {
            GameObject newCoins = Instantiate(_coinPrefab);
            newCoins.transform.SetParent(_platform);
            newCoins.SetActive(false);
            _coins[i] = newCoins;
        }
    }

    public void SpawnCoins()
    {
        int amountCoins = _rnd.Next(_coinsAmount);
            //_coins = new GameObject[_coinsAmount];
        for (int i = 0; i < amountCoins; i++)
        {
            _coins[i].SetActive(true);
            int randomPointIndex = _rnd.Next(0, 3);
            Vector3 spawnPosition = _spawnCoinsPoints[randomPointIndex].position;
            spawnPosition.x += i * _coinsStep;
            GameObject newCoins = Instantiate(_coins[i], spawnPosition, Quaternion.identity);
            newCoins.transform.SetParent(_platform);
            _coins[i] = newCoins;
        }
    }
}