using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private int _step = 2;
    [SerializeField] private float _jumpForce = 2;
    [SerializeField] private LayerMask _groundLayers;

    float _inputMove;
    //private Rigidbody _rb;

    public IEnumerator JumpCoroutine()
    {
        // Debug.Log("Jump" + Time.frameCount);
        transform.Translate(0, _jumpForce, 0);
        yield return new WaitForSeconds(0.75f);
        transform.Translate(0, -_jumpForce, 0);
    }

    public void Move(InputAction.CallbackContext key)
    {
        //Debug.Log("Move " + key.ReadValue<float>());
        _inputMove = key.ReadValue<float>();
        float currentPosition = transform.position.z;
        if (_inputMove == 1 && currentPosition != 2)
            transform.Translate(0, 0, _step);
        if (_inputMove == -1 && currentPosition != -2)
            transform.Translate(0, 0, -_step);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.47f, _groundLayers))
            StartCoroutine(JumpCoroutine());
    }
}

