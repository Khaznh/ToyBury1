using UnityEngine;

public class NoteItem : Item
{
    public override void Interact()
    {
        base.Interact();

        GameController.Instance.SetPlayerCursor(true);
        GameController.Instance.SetPlayerControl(false);
        GameController.Instance.ShowStoryPaper();
    }
}
