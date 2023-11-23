using System.Collections.Generic;
using UnityEngine;

public class GlobalStateMachine
{
    private Dictionary<States, IState> _states = new ();

    private IState _currentState;

    public void AddState(IState state, States stateType)
    {
        _states[stateType] = state;
    }

    public void Start()
    {
        _currentState = _states[States.Playing];
        _currentState.OnEnter();
    }

    public void ChangeState(States stateType)
    {
        _currentState.OnExit();
        _currentState = _states[stateType];
        _currentState.OnEnter();
    }
}