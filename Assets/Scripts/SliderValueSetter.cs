using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class SliderValueSetter : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private string _key;

    private void Start()
    {
        _slider.value = PlayerPrefs.GetFloat(_key, 0.5f);
    }


    private void OnDestroy()
    {
        PlayerPrefs.SetFloat(_key, _slider.value);
    }
}