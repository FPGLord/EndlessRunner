using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageReceiver : MonoBehaviour
{
    //REVIEW сделать код ревью
    private int _lives = 3;
    private void OnTriggerEnter(Collider other)
    {
        TakeLives();
        //Debug.Log($"Collision {gameObject.name} with {other.gameObject.name}");
    }
    
    private void TakeLives()
    {
        _lives--;
        if (_lives == 0)
            Die();
        Debug.Log($"Lives = {_lives}");
    }
    
    private void Die()
    {
       
        SceneManager.LoadScene(0);
    }

    //REVIEW  не работает Корутина
   
}
