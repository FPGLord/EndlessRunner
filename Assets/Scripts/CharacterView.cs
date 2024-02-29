using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _renderer;
    
    private CharacterData _data;
    
    void ViewCat(CharacterData data)
    {
        _data = data;
        _renderer.material = _data.material;
        _renderer.sharedMesh = _data.mesh;
    }
}
