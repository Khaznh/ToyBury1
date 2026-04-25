using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioEventSO sfxChannel;
    [SerializeField] private AudioEventSO backGround;
    [SerializeField] private AudioEventSO uiChannel;
    [SerializeField] private AudioEventSO masterChannel;

    [SerializeField] private AudioMixer mainMixer;

    private void OnEnable()
    {
        sfxChannel.RaiseAudio += PlaySFX;
        backGround.RaiseAudio += PlayBG;
        uiChannel.RaiseAudio += PlaySFX;
        masterChannel.RaiseAudio += PlaySFX;
    }

    private void OnDisable()
    {
        sfxChannel.RaiseAudio -= PlaySFX;
        backGround.RaiseAudio -= PlayBG;
    }

    private void PlaySFX(AudioClip clip, AudioSource source)
    {
        source.PlayOneShot(clip);
    }

    private void PlayBG(AudioClip clip, AudioSource source)
    {
        source.clip = clip;
        source.loop = true;
        source.Play();
    }
}
