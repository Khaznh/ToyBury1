using UnityEngine;
using UnityEngine.UI;

public class SensitivitySlider : MonoBehaviour
{
    [SerializeField] private Slider senSlider;

    private void Start()
    {
        senSlider.onValueChanged.AddListener(OnChangeValue);
    }

    private void OnChangeValue(float sliderValue)
    {
        float actualSensitivity = sliderValue * 0.5f;

        PlayerPrefs.SetFloat("MouseSensitivity", actualSensitivity);
    }
}
