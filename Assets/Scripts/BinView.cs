using UnityEngine;

public class BinView : View<Bin>
{
   
   [SerializeField] private float _spawnChance;
   [SerializeField] private MeshFilter _meshFilter;
    
    private Bin _data;

  public override void ViewData(Bin data)
    {
        _data = data;
        _meshFilter.mesh = _data.mesh;
        _spawnChance = _data.spawnchance;
    }
    
    public override void Activate()
    {
        if (_spawnChance >= Random.Range(0f, 1f))
            base.Activate();
    }
}
