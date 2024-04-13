using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private Transform[] _spawnCoinsPoints;
    [SerializeField] private Transform _platform;
    [SerializeField] private int _coinsAmount; // Общее количество монет для спавна

    private GameObject[] _coins;
    private int _coinsStep = 2;
    private Vector3 _spawnCoinsPosition;
    private int heightAbovePlatform = 1;

    private void Start()
    {
        CreateCoins();
    }

    private void CreateCoins()
    {
        _coins = new GameObject[_coinsAmount];
        for (int i = 0; i < _coinsAmount; i++)
        {
            GameObject newCoins = Instantiate(_coinPrefab);
            newCoins.transform.SetParent(_platform);
            _coins[i] = newCoins;
            newCoins.SetActive(false);
        }
    }

    public void SpawnCoins()
    {
        if (_coins == null)
            CreateCoins();

        int randomPointIndex = Random.Range(0,3); 
           
        Vector3 _spawnCoinsPosition = _spawnCoinsPoints[randomPointIndex].position;

        foreach (var coins in _coins)
        {
            _spawnCoinsPosition.x += _coinsStep;
            coins.transform.position = new Vector3(_spawnCoinsPosition.x, heightAbovePlatform, _spawnCoinsPosition.z);
            coins.transform.SetParent(_platform);
            coins.SetActive(true);
        }

    }
}