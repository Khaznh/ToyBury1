using UnityEngine;

public class TempurationItem : CanPickUpItem
{
    [SerializeField] private AudioClip tempAudio;
    [SerializeField] private AudioEventSO sfxChannel;
    [SerializeField] private AudioSource audioSource;

    public override void Start()
    {
        base.Start();
    }

    public override void Interact()
    {
        if (playerController.hand.transform.childCount != 0)
        {
            ThrowAwayItem(playerController.hand.transform.GetChild(0).gameObject);
        }

        PickUpItem(this.gameObject);

        CanvaManager.Instance.ShowUseText(InteractableType.TempChecker);
    }

    public override void Use()
    {
        base.Use();

        sfxChannel.RaiseEvent(tempAudio, audioSource);

        if (RaycastSource.Instance.currentObject == null || RaycastSource.Instance.currentObject.transform.GetComponentInChildren<Doll>() == null)
        {
            float temp = Random.Range(15f, 22f);
            temp = Mathf.Round(temp * 10f) / 10f;

            TempScreen.Instance.ShowTemp(temp);
        } else
        {
            RaycastSource.Instance?.currentObject?.transform.GetComponentInChildren<Doll>()?.InteractWithDoll(InteractableType.TempChecker);
        }
    }

    public override void OnExitItem()
    {
        ThrowAwayItem(this.gameObject);

        CanvaManager.Instance.HideUseTextImmediate();
    }
}
