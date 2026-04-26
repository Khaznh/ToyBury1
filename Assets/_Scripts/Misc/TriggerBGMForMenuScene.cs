using UnityEngine;

public class TriggerBGMForMenuScene : MonoBehaviour
{
    [SerializeField] private AudioClip menuBGM;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioEventSO bgmChannel;

    private void Start()
    {
        bgmChannel.RaiseEvent(menuBGM, audioSource);
    }
}
