using UnityEngine;

public class RingItem : Item
{
    public override void Interact()
    {
        base.Interact();

        GameController.Instance.SpawnInvestigationSession();
    }
}
