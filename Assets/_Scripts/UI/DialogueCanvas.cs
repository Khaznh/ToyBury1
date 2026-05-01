using DG.Tweening;
using TMPro;
using UnityEngine;

public class DialogueCanvas : Singleton<DialogueCanvas>
{
    [SerializeField] private RectTransform dialoguePanel;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogText;

    [SerializeField] private Vector3 dialoguePanelDis;
    [SerializeField] private Vector3 dialoguePanelShow;

    public GameObject ChooseHolder;
    public GameObject choicePrefap;

    public void ShowDialogue()
    {
        dialoguePanel.DOAnchorPos(dialoguePanelShow, 0.5f).SetEase(Ease.OutBack);
    }

    public void DisableDialogue()
    {
        dialoguePanel.DOAnchorPos(dialoguePanelDis, 0.5f).SetEase(Ease.OutBack);
    }
}
