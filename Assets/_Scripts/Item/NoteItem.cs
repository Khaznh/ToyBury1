using UnityEngine;

public class NoteItem : Item
{
    bool isRead = false;

    public override void Interact()
    {
        base.Interact();

        if (GameController.Instance.currentDoll == null)
        {
            CanvaManager.Instance.ShowDangerText("No assignment to active.");
            return;
        }

        if (isRead)
        {
            GameController.Instance.HideAllPaper();
            GameController.Instance.SetPlayerCursor(false);
            GameController.Instance.SetPlayerControl(true);
            GameController.Instance.ShowTargetCanva();
            isRead = false;
            return;
        }

        GameController.Instance.SetPlayerCursor(true);
        GameController.Instance.SetPlayerControl(false);
        GameController.Instance.ShowStoryPaper();
        GameController.Instance.HideTargetCanva();
        isRead = true;
    }
}
