using UnityEngine;
using UnityEngine.Events;

public class DamageReciever : ScriptableObject
{
    [SerializeField] private UnityEvent _OnDeath;

    private int _lives = 3;

    public void RecieveDamage()
    {
        _lives--;
        if (_lives == 0)
            _OnDeath.Invoke();
    }

    public void ResetLives()
    {
        _lives = 3;
    }
}