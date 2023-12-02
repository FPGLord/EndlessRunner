using UnityEngine;

public class BinView : View<Bin>
{
    [SerializeField] private Material _material;
    
    private Bin _data;

  public override void ViewData(Bin data)
    {
        _data = data;
        _material = _data.material;
    }
    
}
