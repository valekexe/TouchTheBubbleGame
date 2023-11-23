using System;
using UnityEngine;

public class HittingSphereView : SphereView
{
    [field: SerializeField] public Rigidbody Body { get; set;}
    
    public Action<Collider> OnTrigger;

    private void OnTriggerEnter(Collider collider)
    {
        OnTrigger?.Invoke(collider);
    }
}