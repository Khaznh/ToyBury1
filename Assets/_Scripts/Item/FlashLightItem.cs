using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;

public class FlashLightItem : CanPickUpItem
{
    [SerializeField] private Light flashLight;
    private bool isUse = false;

    public override void Start()
    {
        base.Start();
        flashLight.enabled = isUse;
    }

    public override void Interact()
    {
        if (playerController.hand.transform.childCount != 0)
        {
            ThrowAwayItem(playerController.hand.transform.GetChild(0).gameObject);
        }

        PickUpItem(this.gameObject);

        if (isUse)
        {
            AdjustRotation();
        }

        CanvaManager.Instance.ShowUseText(InteractableType.Flashlight);
    }

    public override void Use()
    {
        Debug.Log("Use Light");
        isUse = !isUse;
        flashLight.enabled = isUse;
        AdjustRotation();
    }

    public override void OnExitItem()
    {
        ThrowAwayItem(this.gameObject);

        CanvaManager.Instance.HideUseTextImmediate();
    }

    private void AdjustRotation()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(-13, -13, 0));
    }
}
