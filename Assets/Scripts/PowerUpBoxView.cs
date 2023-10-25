
using UnityEngine;


public class PowerUpBoxView : MonoBehaviour
{
   [SerializeField] private float _spawnChance;
   [SerializeField] private MeshRenderer _meshRenderer;
   [SerializeField] private CollisionTrigger _collisionTrigger;
   
  
   
   private PowerUpBox _data;

   public void ViewData(PowerUpBox data)
   {
       _data = data;
       _meshRenderer.material = _data.material;
       _collisionTrigger.OnTrigger.AddListener(InvokeOnCollision);
   }

   void InvokeOnCollision()
   {
     _data.OnCollision.Invoke();
   }

   private void OnDisable()
   {
       _collisionTrigger.OnTrigger.RemoveListener(InvokeOnCollision);
   }

   public float spawnChance => _spawnChance;
   
}
