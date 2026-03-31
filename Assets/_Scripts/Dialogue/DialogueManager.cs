using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    private DialogueSO currentDialogue;

    private int currentIndex = 0;
    private PlayerInput playerInput;

    public override void Awake()
    {
        base.Awake();
        playerInput = new PlayerInput();
    }

    private void OnEnable()
    {
        playerInput.Enable();
        playerInput.Player.Skip.performed += _ => GoToNextNode();
    }

    private void OnDisable()
    {
        playerInput.Player.Skip.performed -= _ => GoToNextNode();
        playerInput.Disable();
    }

    public void StartDialogue(DialogueSO dialogue)
    {
        currentDialogue = dialogue;
        currentIndex = 0;
        FocusCanvas.Instance.ShowFocus();
        DialogueCanvas.Instance.ShowDialogue();
        DialogueCanvas.Instance.SetDialogue(currentDialogue.dialogueLine[0]);
        GameController.Instance.SetPlayerControl(false);
        GameController.Instance.SetPlayerCursor(true);
    }

    private void EndDialogue()
    {
        FocusCanvas.Instance.DisableFocus();
        DialogueCanvas.Instance.DisableDialogue();
        GameController.Instance.SetPlayerControl(true);
        GameController.Instance.SetPlayerCursor(false);
    }

    public void GoToNode(string nodeID)
    {
        DialogueNode node = currentDialogue.GetNode(nodeID);
        DialogueCanvas.Instance.SetDialogue(node);
    }

    private void GoToNextNode()
    {
        currentIndex++;
        if (currentIndex < currentDialogue.dialogueLine.Count)
        {
            DialogueCanvas.Instance.SetDialogue(currentDialogue.dialogueLine[currentIndex]);
        } else
        {
            EndDialogue();
        }
    }
}
