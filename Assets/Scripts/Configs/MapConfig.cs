using UnityEngine;

[CreateAssetMenu]
public class MapConfig : ScriptableObject
{
    public float MaxObstaclesDensity;
    public float MinObstaclesDensity;
    public int ObstaclesLineCapacity;
    public float EscapeDistance;
    public float YObstaclesOffset;
}