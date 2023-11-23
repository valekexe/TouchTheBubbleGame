using UnityEngine;

public class UiPlaying : IUiState
{
    private GameInfoModel _reservingStats;
    private GameInfoModel _castingStats;

    private Ui _ui;
    
    public UiPlaying(GameInfoModel reservingStats, GameInfoModel castingStats, Ui ui)
    {
        _reservingStats = reservingStats;
        _castingStats = castingStats;
        _ui = ui;
    }

    public void Update()
    {
        _reservingStats.UpdateEnergyBalance();
        _castingStats.UpdateEnergyBalance();
    }

    public void Hide()
    {
        _ui.CapacitySliderView.gameObject.SetActive(false);
        _ui.CastingSphereSliderView.gameObject.SetActive(false);
    }

    public void Show()
    {
        _ui.CapacitySliderView.gameObject.SetActive(true);
        _ui.CastingSphereSliderView.gameObject.SetActive(true);
    }
}