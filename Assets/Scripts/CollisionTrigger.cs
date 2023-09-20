using UnityEngine;
using UnityEngine.Events;

public class CollisionTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _onTrigger;


    private void OnTriggerEnter(Collider other)
    {
        _onTrigger.Invoke();
    }
}