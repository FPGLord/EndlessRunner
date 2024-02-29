using UnityEngine;

public class ChildColliderSetter : MonoBehaviour
{
   public void SetChildCollider(Collider coll)
   {
      Collider collider = GetComponentInChildren<Collider>();
   }
}
