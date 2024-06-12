using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MixerGroupVolumeSetter : MonoBehaviour
{
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private string _parameterName;
    [SerializeField] private float _defaultMinValue = -40;
    
    
    public void SetVolume(float value)
    {
       
        var minValue = value == 0 ? -80 : _defaultMinValue;
       _audioMixer.SetFloat(_parameterName, Mathf.Lerp(minValue, 0, value));
       
    }
}