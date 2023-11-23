using UnityEngine;

public class FinishView : MonoBehaviour, IResetable
{
    [SerializeField] private Door _door;
    [field: SerializeField] public WinnerPoint WinnerPoint { get; set; }
    
    public void Reset()
    {
        _door.CloseDoor(); 
    }
}