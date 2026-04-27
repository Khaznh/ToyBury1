using UnityEngine;

public class RingItem : Item
{
    public AudioClip ringAudio;
    public AudioEventSO sfxChannel;
    public AudioSource audioSource;

    public override void Interact()
    {
        base.Interact();
        sfxChannel.RaiseEvent(ringAudio, audioSource);
        GameController.Instance.SpawnInvestigationSession();
    }
}
