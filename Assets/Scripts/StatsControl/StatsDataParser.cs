public class StatsDataParser : IEnergyProvider
{
    private IEnergyProvider _provider;
    private float _maxValue;
    
    public StatsDataParser(IEnergyProvider provider, float maxValue)
    {
        _provider = provider;
        _maxValue = maxValue;
    }

    public float GetEnergy()
    {
        if (_provider.GetEnergy() == 0)
            return 0;
        
        return _provider.GetEnergy() / _maxValue;
    }
}