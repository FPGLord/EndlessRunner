using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 2;
    [SerializeField] private float _moveSpeed = 2.5f;
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private UnityEvent _OnJump;
    private Player _player;
    private CapsuleCollider _capsuleCollider;
    private int _targetTrack;
    private float _inputMove;
    private Coroutine _smoothMoveCoroutine;

    private void Start()
    {
        _capsuleCollider = GetComponent<CapsuleCollider>();
    }

    private void Update()
    {
        Slide();
    }

    private void SmoothMove()
    {
        var newZ = Mathf.MoveTowards(transform.position.z, _targetTrack, _moveSpeed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, transform.position.y, newZ);
    }


    private IEnumerator JumpCoroutine()
    {
        // Debug.Log("Jump" + Time.frameCount);
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

        _smoothMoveCoroutine ??= StartCoroutine(SmoothMoveCoroutine());
    }

    private IEnumerator SmoothMoveCoroutine()
    {
        while (_targetTrack != transform.position.z)
        {
            SmoothMove();
            yield return null;
        }
        _smoothMoveCoroutine = null;
    }

    public void Jump()
    {
        var isOnGround = Physics.Raycast(transform.position, Vector3.down, 1.47f, _groundLayers);

        if (!isOnGround)
            return;

        StartCoroutine(JumpCoroutine());
        _OnJump.Invoke();
    }

    private IEnumerator SlideCoroutine()
    {
        if (!Input.GetKeyUp(KeyCode.S)) yield break;
        yield return new WaitForSeconds(0.75f);
        _capsuleCollider.direction = 1;
    }

    private void Slide()
    {
        if (Input.GetKeyDown(KeyCode.S))
            _capsuleCollider.direction = 0;
        StartCoroutine(SlideCoroutine());
    }
}