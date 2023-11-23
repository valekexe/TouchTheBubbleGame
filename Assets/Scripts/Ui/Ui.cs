using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class Ui : MonoBehaviour
{
    [field: SerializeField] public SliderView CapacitySliderView { get; set; }
    [field: SerializeField] public SliderView CastingSphereSliderView { get; set; }
    [field: SerializeField] public GameObject WinMenu { get; set; }
    [field: SerializeField] public GameObject LooseMenu { get; set; }
    [field: SerializeField] public Button NextLevelButton { get; set; }
    [field: SerializeField] public Button ResetButton { get; set; }
    [field: SerializeField] public GameObject Container { get; set; }
}