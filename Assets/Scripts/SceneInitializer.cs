using UnityEngine;
using UnityEngine.Events;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField] private UnityEvent onAwake;
    private void Awake()
    {
        onAwake.Invoke();
    }
}
