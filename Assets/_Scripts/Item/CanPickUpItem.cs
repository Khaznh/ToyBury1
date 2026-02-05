using UnityEngine;

public class CanPickUpItem : Item
{
    public PlayerController playerController;

    public virtual void Start()
    {
        playerController = PlayerController.Instance;
    }

    public void ThrowAwayItem(GameObject itemToThrow)
    {
        itemToThrow.transform.SetParent(null, false);
        itemToThrow.transform.position = playerController.hand.transform.position;
        itemToThrow.transform.localScale = Vector3.one;

        itemToThrow.GetComponent<Rigidbody>().isKinematic = false;

        Vector2 throwDir = Camera.main.transform.forward + playerController.forceZAxis * Vector3.forward;
        throwDir = throwDir.normalized;

        itemToThrow.GetComponent<Rigidbody>().AddForce(throwDir * playerController.throwForce, ForceMode.Impulse);
    }

    public void PickUpItem(GameObject itemToPick)
    {
        itemToPick.transform.SetParent(playerController.hand.transform);

        itemToPick.GetComponent<Rigidbody>().isKinematic = true;

        itemToPick.transform.localPosition = Vector3.zero;
        itemToPick.transform.localRotation = Quaternion.identity;
    }
}
