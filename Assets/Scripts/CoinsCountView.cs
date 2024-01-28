using TMPro;
using UnityEngine;

public class CoinsCountView : MonoBehaviour
{
    [SerializeField] private CoinsCounter _coinsCounter;
    [SerializeField] private TextMeshProUGUI _textView;

    private void OnEnable()
    {
        _coinsCounter.onValueChange += UpdateText ;
    }

    private void OnDisable()
    {
        _coinsCounter.onValueChange -= UpdateText ;
    }

    private void UpdateText()
    {
        _textView.text = $"{_coinsCounter.coinsAmount}";
    }
}