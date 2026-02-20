using UnityEngine;

public class ReportPaperItem : CanPickUpItem
{
    [SerializeField] private Vector3 offsetPos;
    [SerializeField] private Vector3 offsetRot;

    public override void Interact()
    {
        if (playerController.hand.transform.childCount != 0)
        {
            ThrowAwayItem(playerController.hand.transform.GetChild(0).gameObject);
        }

        PickUpItem(this.gameObject);
        this.transform.localPosition = offsetPos;
        this.transform.localRotation = Quaternion.Euler(offsetRot);
    }

    public override void Use()
    {
        base.Use();

    }

    public override void OnExitItem()
    {
        ThrowAwayItem(this.gameObject);
    }
}