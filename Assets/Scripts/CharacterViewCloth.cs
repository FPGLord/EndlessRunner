using UnityEngine;

public class CharacterViewCloth : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private CharacterData _data;


    private void Start()
    {
        ViewClothCaracter(_data);
    }

    public void ViewClothCaracter(CharacterData data)
    {
        _data = data;
        _renderer.material = _data.material;
        _renderer.sharedMesh = _data.mesh;
    }
}