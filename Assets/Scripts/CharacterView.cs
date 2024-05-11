using UnityEngine;

public class CharacterView : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _renderer;
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterData _data;

    private void Start()
    {
        ViewCat(_data);
    }

    public void ViewCat(CharacterData data)
    {
        _data = data;
        _renderer.material = _data.material;
        _renderer.sharedMesh = _data.mesh;
        _animator.avatar = _data.avatar;
    }
}
