using System;
using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private UnityEvent _OnJump;
    [SerializeField] private AnimationCurve _jumpCurve;

    private Player _player;
    private CapsuleCollider _capsuleCollider;
    private int _targetTrack;
    private float _inputMove;
    private Tweener _zMover;


    private void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void SmoothJump()
    {
        transform.DOMoveY(transform.position.y + _jumpForce, _jumpDuration/2).SetLoops(2,LoopType.Yoyo).SetEase(_jumpCurve);
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
            .SetEase(Ease.Linear);
    }

    private void OnDestroy()
    {
        if (_zMover != null)
            _zMover.Kill();
    }

    public void Jump()
    {
        var isOnGround = Physics.Raycast(transform.position, Vector3.down, 1.47f, _groundLayers);

        if (!isOnGround)
            return;

        SmoothJump();
        _OnJump.Invoke();
    }
}