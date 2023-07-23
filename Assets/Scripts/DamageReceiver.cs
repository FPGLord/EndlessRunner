using UnityEngine;
using UnityEngine.SceneManagement;

public class DamageReceiver : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacleLayers;
    [SerializeField] private int _lives = 3;
   
    private void OnCollisionEnter(Collision coll)
    {
        if (((1 << coll.gameObject.layer) & _obstacleLayers) != 0)
        {
            _lives--;
            if (_lives == 0)
                Die();
        }
    }
    
   //  public IEnumerator RestartGameCoroutine()
    // {
    //     Time.timeScale = 0;
    //     yield return new WaitForSecondsRealtime(3);
    //     Time.timeScale = 1;
    //     Debug.Log("Time");
    // }
    private void Die()
    {
        SceneManager.LoadScene(0);
       //  StartCoroutine(RestartGameCoroutine());
    }
    
}
