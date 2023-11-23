using UnityEngine;

public class SphereView : MonoBehaviour
{
    [field: SerializeField] public MeshRenderer Renderer { get; set;}
    [field: SerializeField] public float DestroyTime { get; set;}
    [field: SerializeField] public ParticleSystem Particles { get; set; }
    [field: SerializeField] public Collider TirggeredCollider { get; set; }
}
