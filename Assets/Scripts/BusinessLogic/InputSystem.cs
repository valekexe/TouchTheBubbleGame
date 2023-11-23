using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;

public class InputSystem : IUpdateble
{
    public Action OnTrackStart;
    public Action OnTrackFinish;

    private bool _tackUi;

    public bool TrackUi
    {
        set => _tackUi = value;
    }

    public void OnUpdate()
    {
        TrackTouches();
    }

    private void TrackTouches()
    {
        if (IsTouched())
        {
            TrackStarted();
            TrackFinished();
        }
    }

    private void TrackStarted()
    {
        if (IsOnUi == _tackUi && IsStarted(Input.GetTouch(0)))
            OnTrackStart?.Invoke();
    }

    private void TrackFinished()
    {
        if(IsFinished(Input.GetTouch(0)))
            OnTrackFinish?.Invoke();
    }

    private bool IsOnUi => EventSystem.current.IsPointerOverGameObject();

    private bool IsStarted(Touch touch)
    {
        return touch.phase == TouchPhase.Began;
    }

    private bool IsFinished(Touch touch)
    {
        return touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled;
    }

    private bool IsTouched()
    {
        return Input.touchCount > 0;
    }
}