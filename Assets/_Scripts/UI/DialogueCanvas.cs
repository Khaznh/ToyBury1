using DG.Tweening;
using TMPro;
using UnityEngine;

public class DialogueCanvas : Singleton<DialogueCanvas>
{
    [SerializeField] private RectTransform dialoguePanel;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogText;

    [SerializeField] private Vector3 dialoguePanelDis;
    [SerializeField] private Vector3 dialoguePanelShow;

    [SerializeField] private GameObject ChooseHolder;
    [SerializeField] private GameObject choicePrefap;

    public void SetDialogue(DialogueNode dialogueNode)
    {
        nameText.text = dialogueNode.speakerName;
        dialogText.text = dialogueNode.text;

        foreach (Transform child in ChooseHolder.transform)
        {
            Destroy(child.gameObject);
        }

        foreach (var choice in dialogueNode.userChoice)
        {
            GameObject btn = Instantiate(choicePrefap, ChooseHolder.transform);
            btn.GetComponentInChildren<TextMeshProUGUI>().text = choice.choiceText;

            btn.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() => {
                DialogueManager.Instance.GoToNode(choice.nextNodeID);
            });
        }
    }

    public void ShowDialogue()
    {
        dialoguePanel.DOAnchorPos(dialoguePanelShow, 0.5f).SetEase(Ease.OutBack);
    }

    public void DisableDialogue()
    {
        dialoguePanel.DOAnchorPos(dialoguePanelDis, 0.5f).SetEase(Ease.OutBack);
    }
}
