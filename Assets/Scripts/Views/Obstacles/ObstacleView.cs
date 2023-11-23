using UnityEngine;

public class ObstacleView : MonoBehaviour, IPositionControllable, IInteractable, IActivityProvider, IResetable
{
    [SerializeField] private Rigidbody _body;

    public void Interact()
    {
        SetInActive();
    }
    
    public void SetPosition(Vector3 pos)
    {
        gameObject.transform.position = pos;
    }

    public void SetActive()
    {
        gameObject.SetActive(true);
    }

    public void SetInActive()
    {
        gameObject.SetActive(false);
    }

    public void Reset()
    {
        gameObject.transform.rotation = Quaternion.identity;
        _body.isKinematic = true;
        _body.isKinematic = false;
    }
}