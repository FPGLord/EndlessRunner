
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class GlobalEventHandler : MonoBehaviour
{
   [SerializeField] private GlobalEvent globalEvent;
   [SerializeField] private UnityEvent _OnInvoke;
    private void OnEnable()
    {
        globalEvent.OnInvoke.AddListener(Invoke);
    }
    private void OnDisable()
    {
        globalEvent.OnInvoke.RemoveListener(Invoke) ;
    }

    void Invoke()
    {
        _OnInvoke.Invoke();
    }
}
