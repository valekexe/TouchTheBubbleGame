using UnityEngine;

public class FinishFactory : IFactory<FinishView>
{
    private FinishView _prefab;
    private IPositionProvider _positionProvider;
    
    public FinishFactory(FinishView prefab, IPositionProvider positionProvider)
    {
        _prefab = prefab;
        _positionProvider = positionProvider;
    }
    
    public FinishView Create()
    {
        return Object.Instantiate(_prefab, _positionProvider.GetPosition(), Quaternion.identity);
    }
}