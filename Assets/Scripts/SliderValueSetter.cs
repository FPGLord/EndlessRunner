using UnityEngine;
using UnityEngine.UI;

public class SliderValueSetter : MonoBehaviour
{
    [SerializeField] private Slider _slider;
   
    
    private void Start()
    {
      _slider.value = PlayerPrefs.GetFloat("SliderValue");
    }
    
    public void SetValue() 
    {
        PlayerPrefs.SetFloat("SliderValue", _slider.value);
    }
}
