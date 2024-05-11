using UnityEngine;

public class GameObjectView : View<GameObject>
{
    [SerializeField] private float _spawnChance;
   
    private GameObject _data;

    public override void ViewData(GameObject data)
    {
        if (_data is not null)
            Destroy(_data);

        _data = Instantiate(data, transform);
    }

    public override void Activate()
    {
        if (_spawnChance >= Random.value)
            base.Activate();
    }
}