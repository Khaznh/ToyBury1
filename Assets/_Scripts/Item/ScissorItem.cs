using UnityEngine;

public class ScissorItem : CanPickUpItem
{
    public override void Start()
    {
        base.Start();
    }

    public override void Interact()
    {
        if (playerController.hand.transform.childCount != 0)
        {
            ThrowAwayItem(playerController.hand.transform.GetChild(0).gameObject);
        }

        PickUpItem(this.gameObject);

        CanvaManager.Instance.ShowUseText(InteractableType.Scissor);
    }

    public override void Use()
    {

    }

    public override void OnExitItem()
    {
        ThrowAwayItem(this.gameObject);

        CanvaManager.Instance.HideUseTextImmediate();
    }
}
