using UnityEngine;

public class Maria : Doll
{
    private Transform spawnPointTrans;

    private void Awake()
    {
        spawnPointTrans = GameObject.FindWithTag("SpawnPoint").transform;
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

        if (GameController.Instance.mainDoorOpen)
        {
            transform.position = spawnPointTrans.GetChild(0).position;
            transform.rotation = spawnPointTrans.GetChild(0).rotation;
        } else
        {
            transform.position = spawnPointTrans.GetChild(1).position;
            transform.rotation = spawnPointTrans.GetChild(1).rotation;
        }
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
