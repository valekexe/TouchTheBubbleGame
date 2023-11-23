using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SummarPositionProvider : IPositionProvider, IResetable
{
    private Vector3 _currentPosition;
    private MapConfig _config;

    private float _zOffset;


    public SummarPositionProvider(MapConfig config)
    {
        _config = config;
        SetBaseY();
        SetUpZ();
    }
    
    public Vector3 GetPosition()
    {
        return _currentPosition;
    }

    public void Reset()
    {
        ResetZ();
        ResetX();
    }

    public void AddX()
    {
        _currentPosition = new Vector3(_currentPosition.x + GetRandomDistance(),  _config.YObstaclesOffset, _currentPosition.z);
    }

    public void SetBaseY()
    {
        _currentPosition = new Vector3(_currentPosition.x,  _config.YObstaclesOffset, _currentPosition.z);
    }

    public void AddZ()
    {
        _currentPosition = new Vector3(_currentPosition.x, _currentPosition.y, _currentPosition.z +  GetRandomDistance());
    }

    public void ResetZ()
    {
        _currentPosition = new Vector3(_currentPosition.x, _currentPosition.y, -_zOffset);
    }

    private void ResetX()
    {
        _currentPosition = new Vector3(0,  _currentPosition.y, _currentPosition.z);
    }

    private void SetUpZ()
    {
        _zOffset = (_config.MinObstaclesDensity + _config.MaxObstaclesDensity) / 2;
    }

    private float GetRandomDistance()
    {
        return Random.Range(_config.MinObstaclesDensity, _config.MaxObstaclesDensity);
    }
}