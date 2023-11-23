using System.Collections.Generic;

public class LifeCirce
{
    private List<IResetable> _resetables = new ();
    private List<ICreator> _creationProviders = new();

    public void Add(IResetable resetable)
    {
        _resetables.Add(resetable);
    }

    public void Add(ICreator resetable)
    {
        _creationProviders.Add(resetable);
    }

    public void CreateAll()
    {
        foreach (var creatable in _creationProviders)
            creatable.Create();
    }
    
    public void ResetAll()
    {
        foreach (var resetable in _resetables)
            resetable.Reset();
    }
}