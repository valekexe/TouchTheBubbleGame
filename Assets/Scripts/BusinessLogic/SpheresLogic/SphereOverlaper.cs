using UnityEngine;

public class SphereOverlaper : IOverlaper
{
    public void Overlap(Vector3 pos, float radius)
    {
        Collider[] colliders = Physics.OverlapSphere(pos, radius * Constants.OVERLAP_MULTIPLIER );
        Check(colliders);
    }

    private void Check(Collider[] colliders)
    {
        foreach (var collider in colliders)
        {
            if (collider.gameObject.TryGetComponent(out IInteractable explodable))
            {
                explodable.Interact();
            }
        }
    }
}