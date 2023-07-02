using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;



public class PlayerMovement : MonoBehaviour
{
    //[SerializeField] private float _force = -1.85f;
    [SerializeField] private int _step = 2;
    [SerializeField] private float _jumpForce = 2;
    [SerializeField] private LayerMask _groundLayers;
    [SerializeField] private LayerMask _obstacleLayers;
    [SerializeField] private LayerMask _coinLayers;
    [SerializeField] private int _lives = 3;

    float _inputMove;
    private Rigidbody _rb;
    private int _coinsAmount;

    public IEnumerator JumpCoroutine()
    {
        // Debug.Log("Jump" + Time.frameCount);
        transform.Translate(0, _jumpForce, 0);
        yield return new WaitForSeconds(0.75f);
        transform.Translate(0, -_jumpForce, 0);
    }

    public IEnumerator NewLevelCoroutine()
    {
       Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        Debug.Log("Time");
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // transform.Translate(0, 0, _inputMove * _speed * Time.deltaTime);
        // _rb.AddForce(_force, 0, 0);
        //Die();
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

    private void OnCollisionEnter(Collision coll)
    {
        if (((1 << coll.gameObject.layer) & _obstacleLayers) != 0)
        {
            transform.Translate(2, 0, 0);
            _lives --;
            if (_lives == 0)
                Die();
        }

        
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (Physics.Raycast(transform.position, Vector3.down, 1.47f, _groundLayers))
            StartCoroutine(JumpCoroutine());
    }

    private void Die()
    {
        SceneManager.LoadScene(0);
       // StartCoroutine(NewLevelCoroutine());
    }
}