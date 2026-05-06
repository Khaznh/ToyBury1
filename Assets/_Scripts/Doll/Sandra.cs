using System.Collections;
using UnityEngine;

public class Sandra : Doll
{
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
        GameController.Instance.targetCanva.SetActive(true);
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
