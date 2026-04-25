using UnityEngine;

public class TMP_ClickButton : MonoBehaviour
{
    [SerializeField] private AudioClip clickSound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioEventSO uiChannel;

    public void OnClick()
    {
        uiChannel.RaiseEvent(clickSound, audioSource);
    }
}
