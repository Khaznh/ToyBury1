using UnityEngine;

public class Doll : CanPickUpItem
{
    public DollConfig dollSO;
    public DollTestStatus dollTestStatus;

    public AudioEventSO sfxChanel;

    private AudioSource dollAudioSource;

    private void Awake()
    {
        dollAudioSource = GetComponentInChildren<AudioSource>();
        if (dollAudioSource == null)
        {
            Debug.LogError("No audio source found in children of " + gameObject.name);
        }
    }

    public virtual void InteractWithDoll(InteractableType type)
    {
        switch (type)
        {
            case InteractableType.Scissor:
                InteractWithScissor();
                break;
            case InteractableType.TempChecker:
                InteractWithTempuration();
                break;
            case InteractableType.Camera:
                InteractWithCamera();
                break;
            case InteractableType.CallName:
                InteractWithCallName();
                break;
            case InteractableType.Music:
                InteractWithMusic();
                break;
            default:
                Debug.Log("Oi cai ditt"); break;
        }
    }

    protected virtual void InteractWithScissor()
    {
        sfxChanel.RaiseEvent(dollSO.dollStab, dollAudioSource);
    }

    protected virtual void InteractWithTempuration()
    {

    }

    protected virtual void InteractWithMusic()
    {

    }

    protected virtual void InteractWithCallName()
    {

    }

    protected virtual void InteractWithCamera()
    {

    }

    public override void PickUpItem(GameObject itemToPick)
    {
        base.PickUpItem(itemToPick);

        itemToPick.transform.localRotation = Quaternion.Euler(new Vector3(0, 180, 0));
    }
}

[System.Serializable]
public class DollTestStatus
{
    public bool isTestCorrect = false;
    public bool isTypeCorrect = false;
}