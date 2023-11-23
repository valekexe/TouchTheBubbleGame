using UnityEngine;

public class EnergyReserver : IEnergyReserver
{
    private SphereView _view;
    private IExploder _exploder;

    private float _energy;
    private float _viewEnergyChangeMultiplier;

    public SphereView View => _view;
    
    public EnergyReserver(SphereView view, IExploder exploder, float energyMultiplier)
    {
        _view = view;
        _exploder = exploder;
        _viewEnergyChangeMultiplier = energyMultiplier;
    }

    public float GetEnergy() => _energy;

    public void AddEnergy(float offset)
    {
        _energy += offset * Time.deltaTime;
        _view.transform.localScale = Vector3.one * (_energy * _viewEnergyChangeMultiplier);
    }

    public void SetEnergy(float energy)
    {
        _energy = energy;
        _view.transform.localScale = Vector3.one * (_energy * _viewEnergyChangeMultiplier);
    }

    public void ResetEnergy()
    {
        _energy = 0;
        _view.transform.localScale = Vector3.one * _energy;
    }

    public void Explode()
    {
        _exploder.Explode(GetEnergy(), this);
    }
}