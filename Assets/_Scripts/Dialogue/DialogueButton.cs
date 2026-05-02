using UnityEngine;

public class DialogueButton : MonoBehaviour
{
    public DialogueEventType buttonClick = DialogueEventType.None;

    public void OnClickAnswer()
    {
        DialogueManager.Instance.TriggerEvent(buttonClick);
    }
}
