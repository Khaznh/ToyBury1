using System.Collections;
using UnityEngine;

public class Abby : Doll
{
    [SerializeField] private DialogueSO dialogueInfo;
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody rb;
    private BoxCollider boxCollider;

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
    }

    protected override void InteractWithTempuration()
    {
        base.InteractWithTempuration();

        GameController.Instance.isTempuration = true;

        float temp = Random.Range(15f, 22f);
        temp = Mathf.Round(temp * 10f) / 10f;

        TempScreen.Instance.ShowTemp(temp);
    }

    protected override void InteractWithScissor()
    {
        base.InteractWithScissor();

        GameController.Instance.isScissor = true;


        transform.SetParent(null);
        rb.isKinematic = false;
        boxCollider.isTrigger = false;

        Vector3 dirVetor = new Vector3(0, 1f, 0);
        rb.AddForce(dirVetor * jumpForce, ForceMode.Impulse);


        DialogueManager.Instance.StartDialogue(dialogueInfo, dollAudioSource);
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
        StartCoroutine(CallName());
    }

    private IEnumerator CallName()
    {
        GameController.Instance.targetCanva.SetActive(false);
        FocusCanvas.Instance.ShowFocus();
        GameController.Instance.SetPlayerControl(false);
        yield return new WaitForSeconds(1.5f);

        sfxChanel.RaiseEvent(dollSO.dollCallName, GameController.Instance.playerAudioSource);

        yield return new WaitForSeconds(2.5f);
        GameController.Instance.targetCanva.SetActive(false);
        FocusCanvas.Instance.DisableFocus();
        GameController.Instance.SetPlayerControl(true);
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
