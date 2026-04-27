using System.Collections;
using UnityEngine;

public class Anna : Doll
{
    protected override void InteractWithTempuration()
    {
        base.InteractWithTempuration();

        GameController.Instance.isTempuration = true;

        float temp = Random.Range(-20f, -5f);
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

    //protected override void InteractWithCallName()
    //{
    //    base.InteractWithCallName();

    //    GameController.Instance.isCallName = true;

    //    GameController.Instance.ForceToTurnOff();
    //}

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

        yield return new WaitForSeconds(0.5f);

        GameController.Instance.ForceToTurnOff();

        yield return new WaitForSeconds(2f);
        GameController.Instance.targetCanva.SetActive(false);
        FocusCanvas.Instance.DisableFocus();
        GameController.Instance.SetPlayerControl(true);
    }

    protected override void InteractWithMusic()
    {
        base.InteractWithMusic();

        GameController.Instance.isInAudioTest = true;
        GameController.Instance.ForceToTurnOff();
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
