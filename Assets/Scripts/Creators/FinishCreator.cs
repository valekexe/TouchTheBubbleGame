using System.Runtime.CompilerServices;
using UnityEngine;

public class FinishCreator : ICreator, IResetable
{
    private FinishView _finishView;
    
    public FinishCreator(FinishView finishView) 
    {
        _finishView = finishView;
    }

    public void Create()
    {
        _finishView.gameObject.SetActive(true);
    }

    public void Reset()
    {
        _finishView.gameObject.SetActive(false);
        _finishView.Reset();
    }
}