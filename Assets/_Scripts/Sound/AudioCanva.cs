using UnityEngine;
using UnityEngine.UI;

public class AudioCanva : MonoBehaviour
{
    [SerializeField] private Slider masterSlide;
    [SerializeField] private Slider bgmSlide;
    [SerializeField] private Slider sfxSlide;
    [SerializeField] private Slider uiSlide;

    private void OnEnable()
    {
        masterSlide.value = PlayerPrefs.GetFloat("Master", 1f);
        bgmSlide.value = PlayerPrefs.GetFloat("BackgroundMusic", 1f);
        sfxSlide.value = PlayerPrefs.GetFloat("SFX", 1f);
        uiSlide.value = PlayerPrefs.GetFloat("UI", 1f);
    }
}
