using UnityEngine;

public class Winner
{
    private GlobalStateMachine _machine;
    private WinnerPoint _winnerPoint;

    private TriggerSystem _triggers = new ();
    
    public Winner(WinnerPoint winnerPoint, GlobalStateMachine machine)
    {
        _machine = machine;
        _winnerPoint = winnerPoint;
        _winnerPoint.OnTrigger += CheckWin;
    }

    private void CheckWin(Collider collider)
    {
        if(_triggers.IsWin(collider))
            Win();
    }

    private void Win()
    {
        _machine.ChangeState(States.Win);
    }
}