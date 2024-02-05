using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class InputReader : MonoBehaviour
{
    [SerializeField] private InputActionReference _inputActionReference;
    [SerializeField] private UnityEvent _OnInputRead;

    private void OnEnable()
    {
        _inputActionReference.action.performed += ReadInput;
    }

    private void OnDisable()
    {
        _inputActionReference.action.performed -= ReadInput;
    }

    private void ReadInput(InputAction.CallbackContext callbackContext)
    {
        _OnInputRead.Invoke();
    }
}
