

using UnityEngine;

public class Storage : ActivityController, IEnergyStorage, IResetable, IEnergyProvider
{
    private IEnergyReserver _reserver;
    private StorageConfig _config;
    private GlobalStateMachine _stateMachine;

    public IEnergyReserver Reserver => _reserver;

    private float _energyResolved;
    
    public Storage(IEnergyReserver reserver, StorageConfig config, GlobalStateMachine stateMachine, SphereView view) : base(view.gameObject)
    {
        _reserver = reserver;
        _config = config;
        _stateMachine = stateMachine;
    }
    
    public float CreateSphere()
    {
        _energyResolved = 0;
        return ApplyEnergy(_config.MinimalSphereSize);
    }

    public float MakeStep()
    {
        return ApplyEnergy(_config.StepEnergyOffset);
    }

    private float ApplyEnergy(float energy)
    {
        if (TryDestroy() == false && TryValidateEnergy(energy))
            return energy;

        return 0;
    }

    public void Reset()
    {
        _reserver.ResetEnergy();
        _reserver.SetEnergy(_config.StartCapacity);
        _energyResolved = 0;
    }

    private bool TryDestroy()
    {
        if (_reserver.GetEnergy() < _config.MinimalSphereSize)
        {
            Destoroy();
            return true;
        }
        return false;
    }

    private bool TryValidateEnergy(float energy)
    {
        if (_energyResolved < _config.MaxEnergyPerTime)
        {
            _reserver.AddEnergy(-energy);
            _energyResolved += energy * Time.deltaTime;
            return true;
        }
        return false;
    }

    private void Destoroy()
    {
        _stateMachine.ChangeState(States.Lose);
    }

    public float GetEnergy()
    {
        return _reserver.GetEnergy() - _config.MinimalSphereSize;
    }
}