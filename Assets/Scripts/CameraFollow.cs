using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    private Vector3 _offset;
    
    void Start()
    {
        _offset = new Vector3(7,6,0);
    }

    void LateUpdate()
    {
        Vector3 position = _player.transform.position + _offset;
        position.y = transform.position.y;
        position.z = transform.position.z;
        transform.position = position;
    }
}
