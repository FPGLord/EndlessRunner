using System.Collections;
using UnityEngine;

public class StartDelayHandler : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(RestartGameCoroutine());
    }
   
    public IEnumerator RestartGameCoroutine()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
    }
}
