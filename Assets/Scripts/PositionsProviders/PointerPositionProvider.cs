using UnityEngine;

public class PointerPositionProvider : IPositionProvider
{
    private Transform _pointer;
    
    public PointerPositionProvider(Transform pointer)
    {
        _pointer = pointer;
    }
    
    public Vector3 GetPosition()
    {
        return _pointer.position;
    }
}