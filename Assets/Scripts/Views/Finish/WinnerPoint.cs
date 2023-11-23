using System;
using UnityEngine;

public class WinnerPoint : MonoBehaviour
{
    public Action<Collider> OnTrigger;

    private void OnTriggerEnter(Collider collider)
    {
        OnTrigger?.Invoke(collider); 
    }
}