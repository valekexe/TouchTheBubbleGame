using UnityEngine;

public class SpheresCaster : TempObjectsResetor<HittingSphereModel>, ISphereCaster, IEnergyProvider
{
    private HittingSphereModel _castingSphere;
    
    private bool _isCasting;
    
    public SpheresCaster(Pull<HittingSphereModel> pull) : base(pull)
    {
    }

    public void AddEnergy(float capacity)
    {
        _castingSphere.Reserver.AddEnergy(capacity);
    }

    public void Cast(float energy)
    {
        _isCasting = true;
        _castingSphere = Pull.Get();
        _castingSphere.SetKinematic();
        _castingSphere.Reserver.AddEnergy(energy);
        AddActive(_castingSphere);
    }
    
    public void TrowSphere()
    {
        _isCasting = false;
        Vector3 force = new Vector3(_castingSphere.GetEnergy(), 0, 0);
        _castingSphere.SetPhisics();
        _castingSphere.Force(force);
    }
    public float GetEnergy()
    {
        return _isCasting? _castingSphere.GetEnergy(): 0;
    }
}