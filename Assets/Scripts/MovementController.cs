using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 2;
    [SerializeField] private float _moveSpeed = 2.5f;
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private UnityEvent _OnJump;
    [SerializeField] private AnimationCurve _curve;

    private Player _player;
    private CapsuleCollider _capsuleCollider;
    private int _targetTrack;
    private float _inputMove;
    private Tweener _zMover;

    private void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private IEnumerator JumpCoroutine()
    {
        transform.Translate(0, _jumpForce, 0);
        yield return new WaitForSeconds(0.75f);
        transform.Translate(0, -_jumpForce, 0);
    }

    public void Move(InputAction.CallbackContext key)
    {
        _inputMove = key.ReadValue<float>();

        if (Mathf.Approximately(_inputMove, 1) && _targetTrack == 2)
            return;

        if (Mathf.Approximately(_inputMove, -1) && _targetTrack == -2)
            return;

        _targetTrack += (int)_inputMove * 2;

        if (_zMover != null)
            _zMover.Kill();
        var deltaZ = Mathf.Abs(transform.position.z - _targetTrack);
        _zMover = transform.DOMoveZ(_targetTrack, deltaZ / _moveSpeed)
            .SetEase(_curve);
    }

    public void Jump()
    {
        var isOnGround = Physics.Raycast(transform.position, Vector3.down, 1.47f, _groundLayers);

        if (!isOnGround)
            return;
        
        StartCoroutine(JumpCoroutine());
        _OnJump.Invoke();
    }
}