using System.Collections;
using UnityEngine;

public class TriggerItem : Item
{
    private Animator animator;
    private bool isInteracting = false;

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
        yield return new WaitForEndOfFrame();

        if (GameController.Instance.checkTranForSafe.childCount == 0 && GameController.Instance.checkTranForUnSafe.childCount == 0)
        {

        } else if (!GameController.Instance.CanSubmitDoll())
        {

        }
        else
        {
            if (GameController.Instance.checkTranForSafe.childCount > 0)
            {
                GameController.Instance.SubmitDoll(DollStatus.Safe);
            } else if (GameController.Instance.checkTranForUnSafe.childCount > 0)
            {
                GameController.Instance.SubmitDoll(DollStatus.Safe);
            }
        }

        float duration = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(duration);

        animator.Play("Idle");

        isInteracting = false;
    }
}
