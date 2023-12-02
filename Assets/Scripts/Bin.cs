using UnityEngine;


public class Bin : ScriptableObject
{
    [SerializeField] private Material _material;


    public Material material => _material;
}
