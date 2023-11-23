using System;

public class StorageController : IUpdateble, ICreator, IResetable, IEnergyProvider
{
    private bool _isResolving;
    
    private ISphereCaster _sphereCaster;
    private Pull<Storage> _pull;
    
    private Storage _storage;

    public event Action OnEnergyResolving; 
    public StorageController(ISphereCaster caster, Pull<Storage> pull)
    {
        _sphereCaster = caster;
        _pull = pull;
    }
    
    public void Reset()
    {
        _isResolving = false;
        _storage.Reset();
        _pull.Return(_storage);
    }

    public void Create()
    {
        _storage = _pull.Get();
    }

    public float GetEnergy()
    {
        return _storage.GetEnergy();
    }

    public void OnUpdate()
    {
        if(_isResolving)
            ResolveEnergy();
    }

    private void ResolveEnergy()
    {
        _sphereCaster.AddEnergy(_storage.MakeStep());
        OnEnergyResolving?.Invoke();
    }

    public void StopResolveEnergy()
    {
        _sphereCaster.TrowSphere();
        _isResolving = false;
        OnEnergyResolving?.Invoke();
    }

    public void StartResolveEnergy()
    {
        var energyResolved = _storage.CreateSphere();
        _sphereCaster.Cast(energyResolved);
        _isResolving = true;
    }
}