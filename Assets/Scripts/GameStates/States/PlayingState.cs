public class PlayingState : IState
{
    private UiPlaying _uiPlaying;
    private StatesDependencies _dependencies;
    
    public PlayingState(StatesDependencies dependencies, UiPlaying uiPlaying)
    {
        _uiPlaying = uiPlaying;
        _dependencies = dependencies;
    }
    
    public void OnEnter()
    {
        _dependencies.Creation.CreateAll();
        _dependencies.Input.TrackUi = false;
        _dependencies.Updater.StartUpdate();
        _uiPlaying.Show();
        _uiPlaying.Update();
    }

    public void OnExit()
    {
        _uiPlaying.Hide();
    }
}
