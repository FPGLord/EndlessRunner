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
        _collisionTrigger.OnTrigger.AddListener(InvokeOnCollision);
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
        if (_spawnChance >= Random.Range(0f, 1f))
            base.Activate();
    }
}