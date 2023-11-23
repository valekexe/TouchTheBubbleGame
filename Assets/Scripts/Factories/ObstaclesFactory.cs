using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class ObstaclesFactory : IFactory<ObstacleView>
{
    private List<ObstacleView> _views;
    private Transform _parent;
    
    public ObstaclesFactory(List<ObstacleView> views, Transform parent)
    {
        _views = views;
        _parent = parent;
    }

    public ObstacleView Create()
    {
        return Object.Instantiate(GetRandomPrefab(), _parent);
    }

    private ObstacleView GetRandomPrefab()
    {
        return _views[Random.Range(0, _views.Count)];
    }
}