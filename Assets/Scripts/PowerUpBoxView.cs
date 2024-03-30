using UnityEngine;


public class PowerUpBoxView : View<PowerUpBox>
{
    [SerializeField] private float _spawnChance;
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private CollisionTrigger _collisionTrigger;

    private PowerUpBox _data;

    public override void ViewData(PowerUpBox data)
    {
        _data = data;
        _meshRenderer.material = _data.material;
        _spawnChance = _data.spawnChance;
    }

    void InvokeOnCollision()
    {
        _data.OnCollision.Invoke();
    }

    private void OnDisable()
    {
        _collisionTrigger.OnTrigger.RemoveListener(InvokeOnCollision);
    }

    public override void Activate()
    {
        if (Random.value < _spawnChance)
        {
            base.Activate();
            _collisionTrigger.OnTrigger.AddListener(InvokeOnCollision);
        }
    }
}