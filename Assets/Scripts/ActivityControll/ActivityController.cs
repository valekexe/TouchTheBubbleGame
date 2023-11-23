using UnityEngine;

public class ActivityController : IActivityProvider, IPositionControllable
{
    private GameObject _view;
    
    public ActivityController(GameObject view)
    {
        _view = view;
    }
    
    public void SetActive()
    {
        _view.gameObject.SetActive(true);
    }

    public void SetInActive()
    {
        _view.gameObject.SetActive(false);
    }

    public void SetPosition(Vector3 pos)
    {
        _view.gameObject.transform.position = pos;
    }
}