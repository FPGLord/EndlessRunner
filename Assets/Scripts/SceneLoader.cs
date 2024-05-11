using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : ScriptableObject
{
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}