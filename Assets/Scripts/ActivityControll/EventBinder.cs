public class EventBinder
{
    private InputSystem _input;
    private StorageController _storageController;
    private Ui _ui;
    private UiPlaying _uiPlaying;
    private GlobalStateMachine _stateMachine;
    
    public EventBinder(InputSystem input, StorageController storageController, Ui ui, UiPlaying uiPlaying, GlobalStateMachine stateMachine)
    {
        _input = input;
        _storageController = storageController;
        _ui = ui;
        _uiPlaying = uiPlaying;
        _stateMachine = stateMachine;
    }

    public void BindInput()
    {
        _input.OnTrackStart += _storageController.StartResolveEnergy;
        _input.OnTrackFinish += _storageController.StopResolveEnergy;
    }

    public void UnBindInput()
    {
        _input.OnTrackStart -= _storageController.StartResolveEnergy;
        _input.OnTrackFinish -= _storageController.StopResolveEnergy;
    }

    public void BindEnergySystem()
    {
        _storageController.OnEnergyResolving += _uiPlaying.Update;
    }

    public void UnBindEnergySystem()
    {
        _storageController.OnEnergyResolving -= _uiPlaying.Update;
    }

    public void BindUi()
    {
        _ui.ResetButton.onClick.AddListener(() => _stateMachine.ChangeState(States.Playing));
        _ui.NextLevelButton.onClick.AddListener(() => _stateMachine.ChangeState(States.Playing));
    }

    public void UnBindUi()
    {
        _ui.ResetButton.onClick.RemoveAllListeners();
    }
}