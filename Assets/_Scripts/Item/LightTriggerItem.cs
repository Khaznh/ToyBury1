using UnityEngine;

public class LightTriggerItem : Item
{
    [SerializeField] private LightTriggerEntity triggerEntity;

    public override void Interact()
    {
        base.Interact();

        triggerEntity.ChangeCurrentState();
    }
}
