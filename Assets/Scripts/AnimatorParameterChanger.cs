using UnityEngine;

public class AnimatorParameterChanger : MonoBehaviour
{
    [SerializeField] private string _parameterName;
    [SerializeField] private Animator _animator;
    private float _minValue = 1f;

    public void ChangeParameter(float delta)
    {
        var oldValue = _animator.GetFloat(_parameterName);
        if (oldValue > _minValue)
            _animator.SetFloat(_parameterName, oldValue + delta);
    }
}