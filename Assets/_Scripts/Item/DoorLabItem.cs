using UnityEngine;

public class DoorLabItem : Item
{
    private DoorLabEntity doorEntity;

    private void Awake()
    {
        doorEntity = GetComponent<DoorLabEntity>();
    }

    public override void Interact()
    {
        base.Interact();

        doorEntity.InteractWithDoor();
    }
}
