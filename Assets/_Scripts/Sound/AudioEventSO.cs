using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioEvent", menuName = "Audio/Audio Event SO")]
public class AudioEventSO : ScriptableObject
{
    public Action<AudioClip, AudioSource> RaiseAudio;

    public void RaiseEvent(AudioClip clip, AudioSource source)
    {
        RaiseAudio?.Invoke(clip, source);
    }
}
