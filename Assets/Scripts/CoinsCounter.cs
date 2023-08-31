using System;
using UnityEngine;

public class CoinsCounter : ScriptableObject
{
    public event Action onValueChange;
        
    [SerializeField] private int _coinsAmount; //переменная для хранения кол-ва собираемых монет.
    public int coinsAmount => _coinsAmount;
    
    public void AddCoin()
    {
        _coinsAmount++;
        onValueChange?.Invoke();
    }
    
    
    
}