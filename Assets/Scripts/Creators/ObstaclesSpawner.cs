public class ObstaclesSpawner : TempObjectsResetor<ObstacleView>, ICreator
{
    private SummarPositionProvider _positionProvider;
    private MapConfig _config;

    public ObstaclesSpawner(MapConfig config, Pull<ObstacleView> pull, SummarPositionProvider positionProvider) : base(pull)
    {
        _config = config;
        _positionProvider = positionProvider;
    }

    public void Create()
    {
        do
        {
            for (int i = 0; i < _config.ObstaclesLineCapacity; i++)
            {
                AddActive(Pull.Get());
                _positionProvider.AddZ();
            }
            _positionProvider.ResetZ();
            _positionProvider.AddX();
        } while (_positionProvider.GetPosition().x < _config.EscapeDistance);
    }
}