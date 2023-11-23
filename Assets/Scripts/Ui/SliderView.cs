using UnityEngine;
using Slider = UnityEngine.UI.Slider;

public class SliderView : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _animationDuration;
    
    private float _currentValue;

    public void SetValue(float target)
    {
        _slider.value = target;
    }
}