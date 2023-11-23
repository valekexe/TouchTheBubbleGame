public class UiWinningState : IUiState
{
    private Ui _ui;

    public UiWinningState(Ui ui)
    {
        _ui = ui;
    }

    public void Show()
    {
        _ui.WinMenu.SetActive(true);
        _ui.NextLevelButton.gameObject.SetActive(true);
        _ui.ResetButton.gameObject.SetActive(true);
        _ui.Container.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _ui.WinMenu.SetActive(false);
        _ui.NextLevelButton.gameObject.SetActive(false);
        _ui.ResetButton.gameObject.SetActive(false);
        _ui.Container.gameObject.SetActive(false);
    }
}
