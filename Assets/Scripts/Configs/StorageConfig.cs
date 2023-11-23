using UnityEngine;

[CreateAssetMenu]
public class StorageConfig : ScriptableObject
{
    public float StartCapacity;
    public float MinimalSphereSize;
    public float StepEnergyOffset;
    public float MaxEnergyPerTime;
    public float ViewEmergyChangeMultoplier;
}