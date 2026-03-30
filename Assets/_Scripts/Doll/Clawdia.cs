using UnityEngine;

public class Clawdia : Doll
{
    [SerializeField] private float jumpForce = 5f;

    private Rigidbody rb;
    private BoxCollider boxCollider;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    protected override void InteractWithTempuration()
    {
        base.InteractWithTempuration();

        GameController.Instance.isTempuration = true;

        float temp = Random.Range(-15f, -3f);
        temp = Mathf.Round(temp * 10f) / 10f;

        TempScreen.Instance.ShowTemp(temp);
    }

    protected override void InteractWithScissor()
    {
        base.InteractWithScissor();

        GameController.Instance.isScissor = true;
    }

    protected override void InteractWithCamera()
    {
        base.InteractWithCamera();

        GameController.Instance.isPhotoTaken = true;
    }

    protected override void InteractWithCallName()
    {
        base.InteractWithCallName();

        GameController.Instance.isCallName = true;

        transform.SetParent(null);
        rb.isKinematic = false;
        boxCollider.isTrigger = false;

        Vector3 dirVetor = new Vector3(1f,0.3f,0);
        rb.AddForce(dirVetor * jumpForce, ForceMode.Impulse);
    }

    protected override void InteractWithMusic()
    {
        base.InteractWithMusic();

        GameController.Instance.isInAudioTest = true;
    }

    public override void Interact()
    {
        if (playerController.hand.transform.childCount != 0)
        {
            ThrowAwayItem(playerController.hand.transform.GetChild(0).gameObject);
        }

        PickUpItem(this.gameObject);
    }

    public override void OnExitItem()
    {
        ThrowAwayItem(this.gameObject);
    }
}
