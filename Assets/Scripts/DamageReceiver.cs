using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField]private Player _player;
    private int _lives = 3;

    private void TakeLives()
    {
        _lives--;
        if (_lives == 0)
            _player.Die();
    }

    private void OnTriggerEnter(Collider other)
    {
        TakeLives();
    }
}