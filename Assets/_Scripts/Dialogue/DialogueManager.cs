using DG.Tweening;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private DialogueSO testDia;
    [SerializeField] private AudioEventSO sfxChannel;

    private AudioSource currentAudioSource;

    private Queue<DialogueLine> dialogueLines = new();
    private bool isTyping = false;

    private PlayerInput playerInput;
    private DialogueLine line;

    private void OnEnable()
    {
        playerInput = new PlayerInput();
        playerInput.Enable();
        playerInput.Player.Skip.performed += OnSkipPressed;
    }

    private void OnDisable()
    {
        playerInput.Player.Skip.performed -= OnSkipPressed;
        playerInput.Disable();
    }


    private void OnSkipPressed(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        SkipDialogue();
    }

    public void StartDialogue(DialogueSO dialogue, AudioSource audioSource)
    {
        dialogueLines.Clear();
        currentAudioSource = audioSource;
        foreach (var line in dialogue.dialogueLines)
        {
            dialogueLines.Enqueue(line);
        }

        DialogueCanvas.Instance.ShowDialogue();
        FocusCanvas.Instance.ShowFocus();
        GameController.Instance.SetPlayerControl(false);
        GameController.Instance.SetPlayerCursor(true);

        DisplayDialogueLine();
    }

    private void DisplayDialogueLine()
    {
        if (isTyping) { return; }

        if (dialogueLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        line = dialogueLines.Dequeue();

        DialogueCanvas.Instance.nameText.text = line.speakerName;
        DialogueCanvas.Instance.dialogText.text = line.dialogueText;

        isTyping = true;

        DialogueCanvas.Instance.dialogText.ForceMeshUpdate();
        int totalCharacters = DialogueCanvas.Instance.dialogText.textInfo.characterCount;

        float duration = 0f;

        if (line.audioClip != null)
        {
            sfxChannel.RaiseEvent(line.audioClip, currentAudioSource);
            duration = line.audioClip.length;
        }
        else
        {
            duration = totalCharacters * 0.05f;
        }


        DialogueCanvas.Instance.dialogText.maxVisibleCharacters = 0;
        DOTween.To(() => DialogueCanvas.Instance.dialogText.maxVisibleCharacters,
           x => DialogueCanvas.Instance.dialogText.maxVisibleCharacters = x,
           totalCharacters,
           duration)
        .SetEase(Ease.Linear)
        .SetTarget(DialogueCanvas.Instance.dialogText)
        .SetUpdate(true)
        .OnComplete(() =>
        {
            isTyping = false;
            DialogueCanvas.Instance.dialogText.maxVisibleCharacters = totalCharacters;
        });
    }

    private void SkipDialogue()
    {
        if (isTyping) 
        {
            currentAudioSource.Stop();
            DOTween.Complete(DialogueCanvas.Instance.dialogText);
        } else
        {
            DisplayDialogueLine();
        }
    }

    public void EndDialogue()
    {
        dialogueLines.Clear();
        currentAudioSource = null;
        DialogueCanvas.Instance.DisableDialogue();
        FocusCanvas.Instance.DisableFocus();
        GameController.Instance.SetPlayerControl(true);
        GameController.Instance.SetPlayerCursor(false);
    }
}
