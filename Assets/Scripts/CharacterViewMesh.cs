using System;
using UnityEngine;

public class CharacterViewMesh : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private CharacterData _data;


    private void Start()
    {
        ViewMechCaracter(_data);
    }

    public void ViewMechCaracter(CharacterData data)
    {
        _data = data;
        _renderer.material = _data.material;
        _renderer.sharedMesh = _data.mesh;
    }
}