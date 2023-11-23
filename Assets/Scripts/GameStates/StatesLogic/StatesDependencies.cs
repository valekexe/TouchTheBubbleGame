using Unity.VisualScripting;

public class StatesDependencies
{
    private InputSystem _input;
    private Updater _updater;
    private LifeCirce _lifeCirce;

    public LifeCirce Creation => _lifeCirce;
    public Updater Updater => _updater;
    public InputSystem Input => _input;
    
    public StatesDependencies(InputSystem input, Updater updater, LifeCirce lifeCirce)
    {
        _lifeCirce = lifeCirce;
        _input = input;
        _updater = updater;
    }
}