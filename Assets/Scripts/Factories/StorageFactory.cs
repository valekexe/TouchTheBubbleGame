using UnityEngine;

public class StorageFactory : IFactory<Storage>
{
    private StorageConfig _config;
    private SphereView _viewPrefab;
    private GlobalStateMachine _stateMachine;
    private IExploder _exploder;
    
    public StorageFactory(StorageConfig config, SphereView viewPrefab, IExploder exploder, GlobalStateMachine stateMachine)
    {
        _config = config;
        _viewPrefab = viewPrefab;
        _exploder = exploder;
        _stateMachine = stateMachine;
    }
    
    public Storage Create()
    {
        var spehreView = Object.Instantiate(_viewPrefab);

        EnergyReserver model = new EnergyReserver(spehreView, _exploder, _config.ViewEmergyChangeMultoplier);
        model.SetEnergy(_config.StartCapacity);

        Storage storage = new Storage(model, _config, _stateMachine, spehreView);
        return storage;
    }
}