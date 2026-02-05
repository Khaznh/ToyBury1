using UnityEngine;

public class Doll : MonoBehaviour
{
    public DollConfig dollSO;

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
