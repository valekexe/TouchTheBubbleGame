using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour
{ 
    [SerializeField] private float _openingTime;

    public void CloseDoor()
    {
        transform.DORotate(Vector3.zero, _openingTime);
    }

    private void OpenDoor()
    {
        transform.DORotate(new Vector3(0, 90, 0), _openingTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == Constants.CASTED_SPHERE_LAYER)
            OpenDoor();
    }
}