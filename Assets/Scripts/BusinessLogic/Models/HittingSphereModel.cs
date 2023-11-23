using UnityEngine;

public class HittingSphereModel : ActivityController, IResetable, IExplodable
{
    private HittingSphereView _view;
    private SphereConfig _config;
    private TriggerSystem _triggerSystem;
    private IEnergyReserver _energyReserver;

    public IEnergyReserver Reserver => _energyReserver;


    public HittingSphereModel(HittingSphereView view, IEnergyReserver energyReserver, SphereConfig config, TriggerSystem triggering) : base(view.gameObject)
    {
        _view = view;
        _energyReserver = energyReserver;
        _config = config;
        _triggerSystem = triggering;
        _view.OnTrigger += OnTrigger;
    }

    private void OnTrigger(Collider collider)
    {
        _triggerSystem.ParseTrigger(collider, Reserver);
    }

    public void Reset()
    {
        _energyReserver.ResetEnergy();
    }

    public float GetEnergy() => _energyReserver.GetEnergy();

    public void Force(Vector3 forceDirection)
    {
        _view.Body.velocity += (forceDirection * _config.DirectionMultiplier);
    }

    public void SetPhisics()
    {
        _view.Body.isKinematic = false;
    }

    public void SetKinematic()
    {
        _view.Body.isKinematic = true;
    }

    public void Explode()
    {
        _energyReserver.Explode();
    }
}