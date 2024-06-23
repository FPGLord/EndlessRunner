using UnityEngine;
using UnityEngine.Events;

public class AudioClipGlobalEvent : ScriptableObject
{
    public UnityEvent<AudioClip> OnInvoke;
    
    public void Invoke(AudioClip audioClip)
    {
        OnInvoke.Invoke(audioClip);
    }
}
