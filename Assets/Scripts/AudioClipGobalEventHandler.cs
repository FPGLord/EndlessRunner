using UnityEngine;
using UnityEngine.Events;

public class AudioClipGlobalEventHandler : MonoBehaviour
{
   [SerializeField] private AudioClipGlobalEvent globalEvent;
   [SerializeField] private UnityEvent<AudioClip> _OnInvoke;
    private void OnEnable()
    {
        globalEvent.OnInvoke.AddListener(Invoke);
    }
    private void OnDisable()
    {
        globalEvent.OnInvoke.RemoveListener(Invoke) ;
    }

    void Invoke(AudioClip audioClip)
    {
        _OnInvoke.Invoke(audioClip);
    }
}
