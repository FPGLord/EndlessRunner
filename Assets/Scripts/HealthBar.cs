using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image[] _image;
    [SerializeField] private float _fillSpeed = 0.04f;
    
    private float _minValue = 0;
    private float _maxValue = 1.1f;

    private void Start()
    {
        SetMinValueHerats();
        StartCoroutine(FillCoroutine());
    }


    private void SetMinValueHerats()
    {
        foreach (var heart in _image)
        {
            heart.fillAmount = _minValue;
        }
    }

    private IEnumerator FillCoroutine()
    {
        for (float fillAmount = _minValue; fillAmount <= _maxValue; fillAmount += _fillSpeed)
        {
            foreach (var heart in _image)
            {
                heart.fillAmount = fillAmount;
                yield return new WaitForFixedUpdate();
            }
        }
    }

    public IEnumerator ReleaseCoroutine()
    {
        for (float releaseAmount = _maxValue; releaseAmount >= _minValue; releaseAmount -= 0.08f)
        {
            foreach (var heart in _image)
            {
                heart.fillAmount = releaseAmount;
                yield return new WaitForSeconds(0.03f);
            }
        }
    }
}