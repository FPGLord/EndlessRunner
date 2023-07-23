using UnityEngine;

public class ObstacleCollider : MonoBehaviour
{
    [SerializeField] private LayerMask _obstacleLayers;
   
    private void OnCollisionEnter(Collision coll)
    {
        if (((1 << coll.gameObject.layer) & _obstacleLayers) != 0)
        {
            transform.Translate(2, 0, 0);
        }
    }
}
