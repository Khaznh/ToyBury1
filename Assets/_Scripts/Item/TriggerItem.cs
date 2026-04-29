using System.Collections;
using UnityEngine;

public class TriggerItem : Item
{
    private Animator animator;
    private bool isInteracting = false;

    [SerializeField] private AudioClip levelAudio;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioEventSO sfxChannel;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        if (isInteracting) return;
        base.Interact();

        StartCoroutine(PlaySequence());
    }

    private IEnumerator PlaySequence()
    {
        isInteracting = true;

        animator.Play("TriggerPullDown");
        sfxChannel.RaiseEvent(levelAudio, audioSource);
        yield return new WaitForEndOfFrame();

        if (GameController.Instance.checkTranForSafe.childCount == 0 && GameController.Instance.checkTranForUnSafe.childCount == 0)
        {
            CanvaManager.Instance.ShowDangerText("A doll is missing from either of the boxes.");
        } else if (!GameController.Instance.CanSubmitDoll())
        {
            CanvaManager.Instance.ShowDangerText("The test sheet has not been fully filled out.");
        }
        else
        {
            if (GameController.Instance.checkTranForSafe.childCount > 0)
            {
                GameController.Instance.SubmitDoll(DollStatus.Safe);
            } else if (GameController.Instance.checkTranForUnSafe.childCount > 0)
            {
                GameController.Instance.SubmitDoll(DollStatus.Unsafe);
            }
        }

        float duration = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(duration);

        animator.Play("Idle");

        isInteracting = false;
    }
}
