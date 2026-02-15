using UnityEngine;

public class TestDoll : Doll     
{
    protected override void InteractWithTempuration()
    {
        base.InteractWithTempuration();

        Debug.Log("AAAAAAAAAAAAAAAAAAAA");
    }

    protected override void InteractWithScissor()
    {
        base.InteractWithScissor();
    }

    public override void Interact()
    {
        if (playerController.hand.transform.childCount != 0)
        {
            ThrowAwayItem(playerController.hand.transform.GetChild(0).gameObject);
        }

        PickUpItem(this.gameObject);
    }

    public override void OnExitItem()
    {
        ThrowAwayItem(this.gameObject);
    }
}
