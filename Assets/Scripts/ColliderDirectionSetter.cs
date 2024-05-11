using UnityEngine;

public class ColliderDirectionSetter : MonoBehaviour
{
    [SerializeField] private CapsuleCollider _collider;
    
    public void SetDirection(ColliderDirection colliderDirection)
    {
        _collider.direction = (int)colliderDirection;
    }
}

public enum ColliderDirection
{
    horizontal,
    vertical
}
