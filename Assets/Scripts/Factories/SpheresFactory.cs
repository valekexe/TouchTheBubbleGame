using UnityEngine;

public class SpheresFactory : IFactory<HittingSphereModel>
{
    private HittingSphereView _prefab;
    private SphereConfig _sphereConfig;
    private TriggerSystem _triggerSystem = new ();
    private IExploder _exploder;
    private Transform _parent;


    public SpheresFactory(HittingSphereView view, SphereConfig config, IExploder exploder, Transform parent)
    {
        _prefab = view;
        _sphereConfig = config;
        _exploder = exploder;
        _parent = parent;
    }
    
    public HittingSphereModel Create()
    {
        var sphereView = Object.Instantiate(_prefab, _parent);
        sphereView.gameObject.SetActive(false);

        return new HittingSphereModel(sphereView,
            new EnergyReserver(sphereView, _exploder, _sphereConfig.ViewEnergyChangeMultiplier),
            _sphereConfig, _triggerSystem);
    }
}
