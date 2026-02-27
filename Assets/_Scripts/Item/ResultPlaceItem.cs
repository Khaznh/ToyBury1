using UnityEngine;
using UnityEngine.UIElements;

public class ResultPlaceItem : Item
{
    [SerializeField] private Transform placeTrans;

    public override void Interact()
    {
        base.Interact();
        if (placeTrans.childCount == 0)
        {
            if (PlayerController.Instance.hand.transform.childCount == 0)
            {
                return;
            }

            if (PlayerController.Instance.hand.transform.GetChild(0).GetComponent<Doll>() == null)
            {
                return;
            }

            PlayerController.Instance.hand.transform.GetChild(0).SetParent(placeTrans);
            placeTrans.transform.GetChild(0).localPosition = Vector3.zero;
            placeTrans.transform.GetChild(0).localRotation = Quaternion.Euler(new Vector3(0, 90, 0));
            placeTrans.transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = true;
            return;
        }

        if (PlayerController.Instance.hand.transform.childCount != 0)
        {
            ThrowAwayItem(PlayerController.Instance.hand.transform.GetChild(0).gameObject);
        }

        placeTrans.transform.GetChild(0).SetParent(PlayerController.Instance.hand.transform);
        PlayerController.Instance.hand.transform.GetChild(0).localPosition = Vector3.zero;
        PlayerController.Instance.hand.transform.GetChild(0).localRotation = Quaternion.Euler(Vector3.zero);
        PlayerController.Instance.hand.transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = false;
    }

    public void ThrowAwayItem(GameObject itemToThrow)
    {
        itemToThrow.transform.SetParent(null, false);
        itemToThrow.transform.position = PlayerController.Instance.hand.transform.position;
        itemToThrow.transform.localScale = Vector3.one;

        itemToThrow.GetComponent<Rigidbody>().isKinematic = false;

        Vector2 throwDir = Camera.main.transform.forward + PlayerController.Instance.forceZAxis * Vector3.forward;
        throwDir = throwDir.normalized;

        itemToThrow.GetComponent<Rigidbody>().AddForce(throwDir * PlayerController.Instance.throwForce, ForceMode.Impulse);
    }
}
