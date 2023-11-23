public class UiLoosingState : IUiState
{
    private Ui _ui;
    
    public UiLoosingState(Ui ui)
    {
        _ui = ui;
    }

    public void Show()
    {
        _ui.Container.gameObject.SetActive(true);
        _ui.LooseMenu.SetActive(true);
        _ui.ResetButton.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _ui.Container.gameObject.SetActive(false);
        _ui.LooseMenu.SetActive(false);
        _ui.ResetButton.gameObject.SetActive(false);
    }
}