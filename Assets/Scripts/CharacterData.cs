
using UnityEngine;

public class CharacterData : ScriptableObject
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Material _material;


    public Mesh mesh => _mesh;

    public Material material => _material;
}
