using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public void Die()
    {
        SceneManager.LoadScene(0);
    }
}