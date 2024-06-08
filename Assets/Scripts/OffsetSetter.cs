using UnityEngine;

public class OffsetSetter : MonoBehaviour
{
    [SerializeField] private Conveyer _conveyer;
    [SerializeField] private MeshRenderer _mesh;
    [SerializeField] private float _moveSpeed;
    
    private void Update()
    {
        SetOffset();
    }

    private void SetOffset()
    {
        Vector2 offsetX = _mesh.material.mainTextureOffset;
        offsetX.x += (_conveyer.moveSpeed  * Time.deltaTime)/_moveSpeed;
        if (offsetX.x > 40)
            offsetX = new Vector2(0,0);
        _mesh.material.mainTextureOffset = offsetX;
    }
     
}
