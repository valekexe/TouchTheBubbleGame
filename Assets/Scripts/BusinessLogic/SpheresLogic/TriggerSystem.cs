using UnityEngine;

public class TriggerSystem
{
    public void ParseTrigger(Collider collider, IExplodable explodable)
    {
        var colliderLayer = collider.gameObject.layer;
        
        switch (colliderLayer)
        {
            case Constants.OBSTACLE_LAYER: 
                explodable.Explode();
                break;
        }
    }
    
    public bool IsWin(Collider collider)
    {
        var colliderLayer = collider.gameObject.layer;
        
        return colliderLayer == Constants.CASTED_SPHERE_LAYER;
    }
}