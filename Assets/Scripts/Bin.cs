using UnityEngine;

public class Bin : ScriptableObject
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private float _spawnChance;

    public Mesh mesh => _mesh;
    public float spawnchance => _spawnChance;
}
