
public class GameInfoModel
{
    private SliderView _reserveCapacity;
    private IEnergyProvider _reserveStatus;
    
    public GameInfoModel(SliderView slider, IEnergyProvider castingSphere)
    {
        _reserveCapacity = slider;
        _reserveStatus = castingSphere;
    }

    public void UpdateEnergyBalance()
    {
        _reserveCapacity.SetValue(_reserveStatus.GetEnergy());
    }
}