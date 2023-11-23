public class FinishingState : IState
{
    private IUiState _uiState;
    private StatesDependencies _dependencies;
    
    public FinishingState(StatesDependencies dependencies, IUiState uiState)
    {
        _dependencies = dependencies;
        _uiState = uiState;
    }

    public void OnEnter()
    {
        _dependencies.Input.TrackUi = false;
        _dependencies.Creation.ResetAll();
        _dependencies.Updater.StopUpdate();
        _uiState.Show();
    }

    public void OnExit()
    {
        _uiState.Hide();
    }
}