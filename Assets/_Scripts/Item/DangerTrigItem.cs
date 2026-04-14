using UnityEngine;

public class DangerTrigItem : Item
{
    [SerializeField] private DoorLabEntity doorLab;

    public override void Interact()
    {
        base.Interact();

        doorLab.InteractWithDoor();
    }
}
