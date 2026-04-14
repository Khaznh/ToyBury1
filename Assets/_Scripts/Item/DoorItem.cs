using UnityEngine;

public class DoorItem : Item
{
    private DoorEntity doorEntity;

    private void Awake()
    {
        doorEntity = GetComponent<DoorEntity>();
    }

    public override void Interact()
    {
        base.Interact();

        doorEntity.InteractWithDoor();
    }
}
