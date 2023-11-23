using System.Collections.Generic;
using UnityEngine;

public class Updater : MonoBehaviour
{
    private List<IUpdateble> _updatebles = new ();

    private bool _isEnableToUpdate;

    public void StartUpdate() => _isEnableToUpdate = true;
    public void StopUpdate() => _isEnableToUpdate = false;

    public void Add(IUpdateble updateble)
    {
        _updatebles.Add(updateble);
    }

    public void Exclude(IUpdateble updateble)
    {
        _updatebles.Remove(updateble);
    }

    private void Update()
    {
        if(_isEnableToUpdate)
        {
            foreach (var updateble in _updatebles)
                updateble.OnUpdate();   
        }
    }
}