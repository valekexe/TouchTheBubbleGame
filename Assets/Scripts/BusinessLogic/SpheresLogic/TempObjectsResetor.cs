using System.Collections.Generic;

public abstract class TempObjectsResetor<T> : IResetable where T : IPositionControllable, IActivityProvider, IResetable
{
    protected List<T> ActiveObjects = new ();
    protected Pull<T> Pull;

    public TempObjectsResetor(Pull<T> pull)
    {
        Pull = pull;
    }

    public void AddActive(T resetable)
    {
        ActiveObjects.Add(resetable);
    }

    public virtual void Reset()
    {
        foreach (var activeObject in ActiveObjects)
        {
            activeObject.Reset();
        }
        
        Pull.Return(ActiveObjects);
        ActiveObjects.Clear();
    }
}