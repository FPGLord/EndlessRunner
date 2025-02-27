using UnityEngine;
using UnityEngine.Events;

public class PowerUpBox : ScriptableObject
{
   [SerializeField] private Material _material;
   [SerializeField] private float _spawnChance;
   [SerializeField] private UnityEvent _OnCollision;

   public UnityEvent OnCollision => _OnCollision;

   public Material material => _material;

   public float spawnChance => _spawnChance;
}
