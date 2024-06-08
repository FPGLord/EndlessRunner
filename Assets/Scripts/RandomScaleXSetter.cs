using UnityEngine;


public class RandomScaleXSetter : MonoBehaviour
{
    [SerializeField] private int[] _values;

    public void Set(Transform targetTransform)
    {
        var randomIndex = Random.Range(0, _values.Length);
        targetTransform.SetScaleX(_values[randomIndex]);
    }
}