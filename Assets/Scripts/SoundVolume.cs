using UnityEngine;
using UnityEngine.UI;

public class SoundVolume : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Slider _slider;


    private void Update()
    {
        SetVolume();
    }

    private void SetVolume()
    {
        _audioSource.volume = _slider.value;
    }
    
}
