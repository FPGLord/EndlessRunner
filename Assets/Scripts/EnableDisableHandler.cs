using UnityEngine;
using UnityEngine.Events;


public class EnableDisableHandler : MonoBehaviour
{
    [SerializeField] private UnityEvent _OnEnable;
    [SerializeField] private UnityEvent _OnDisable;

    private void OnEnable()
    {
        _OnEnable.Invoke();
    }

    private void OnDisable()
    {
        _OnDisable.Invoke();       
    }

}
