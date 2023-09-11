using System;
using UnityEngine;
using UnityEngine.Events;

public class DamageReciever : ScriptableObject
{
    //[SerializeField]private Player _player;
    [SerializeField] private UnityEvent onDeath;
    private int _lives = 3;
    
    // private void OnTriggerEnter(Collider other)
    // {
    //     TakeLives();
    // }

    public void RecieveDamage()
    {
        _lives--;
        if (_lives == 0)
            onDeath.Invoke();
    }

    public void ResetLives()
    {
        _lives = 3;
    }

}