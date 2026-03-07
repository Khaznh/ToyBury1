using UnityEngine;

public class Doll : CanPickUpItem
{
    public DollConfig dollSO;
    public DollTestStatus dollTestStatus;

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
}

[System.Serializable]
public class DollTestStatus
{
    public bool isTestCorrect = false;
    public bool isTypeCorrect = false;
}