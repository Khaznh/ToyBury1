using UnityEngine;

public class ChairItem : Item
{
    [SerializeField] private Transform sitTransform;

    // nhat va dat bup be len ghe
    public override void Interact()
    {
        base.Interact();

        // dat bup be len ghe
        if (sitTransform.childCount == 0)
        {
            if (PlayerController.Instance.hand.transform.childCount == 0)
            {
                return;
            }

            if (PlayerController.Instance.hand.transform.GetChild(0).GetComponent<Doll>() == null)
            {
                return;
            }

            PlayerController.Instance.hand.transform.GetChild(0).SetParent(sitTransform);
            sitTransform.transform.GetChild(0).localPosition = Vector3.zero;
            sitTransform.transform.GetChild(0).localRotation = Quaternion.Euler(Vector3.zero);
            sitTransform.transform.GetChild(0).GetComponent<BoxCollider>().isTrigger = true;
            return;
        }

        // nhat bup be tren ghe
        if (PlayerController.Instance.hand.transform.childCount != 0)
        {
            ThrowAwayItem(PlayerController.Instance.hand.transform.GetChild(0).gameObject);
        }

        sitTransform.transform.GetChild(0).SetParent(PlayerController.Instance.hand.transform);
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
