using UnityEngine;
using UnityEngine.UI;

public class SensitivityCanva : MonoBehaviour
{
    [SerializeField] private Slider senSlider;

    private void OnEnable()
    {
        senSlider.value = PlayerPrefs.GetFloat("MouseSensitivity", 0.5f) * 2f;
    }
}
