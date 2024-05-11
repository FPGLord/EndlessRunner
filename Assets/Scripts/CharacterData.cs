using UnityEngine;

public class CharacterData : ScriptableObject
{
    [SerializeField] private Mesh _mesh;
    [SerializeField] private Material _material;
    [SerializeField] private Avatar _avatar;
    
    public Mesh mesh => _mesh;

    public Material material => _material;

    public Avatar avatar => _avatar;

    public void LoadData(CharacterData data)
    {
        _mesh = data._mesh;
        _material = data.material;
        _avatar = data.avatar;
    }
}
