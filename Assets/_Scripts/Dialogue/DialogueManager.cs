using DG.Tweening;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : Singleton<DialogueManager>
{
    [SerializeField] private DialogueSO tutorialSO;
    [SerializeField] private DialogueSO startSO;
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

    private void Start()
    {
        if (SaveGameManager.Instance.newGame)
        {
            StartDialogue(startSO, GameController.Instance.endGameSource);
        }
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

        if (DialogueCanvas.Instance.ChooseHolder.transform.childCount > 0)
        {
            foreach (Transform child in DialogueCanvas.Instance.ChooseHolder.transform)
            {
                Destroy(child.gameObject);
            }
        }

        foreach (var answer in line.answers)
        {
            GameObject choice = Instantiate(DialogueCanvas.Instance.choicePrefap, DialogueCanvas.Instance.ChooseHolder.transform);
            choice.GetComponentInChildren<TextMeshProUGUI>().text = answer.answerText;
            choice.GetComponent<DialogueButton>().buttonClick = answer.eventType;
        }

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
            if (line.answers.Count > 0) { return; }
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

    public void TriggerEvent(DialogueEventType eventType)
    {
        switch (eventType)
        {
            case DialogueEventType.WantToSeeTutorial:
                EndDialogue();
                TutoralCanva.Instance.YourJobTutorial.SetActive(true);
                StartDialogue(tutorialSO, GameController.Instance.endGameSource);
                GameController.Instance.targetCanva.SetActive(false);
                break;
            case DialogueEventType.AudioTestTutorial:
                TutoralCanva.Instance.YourJobTutorial.SetActive(false);
                TutoralCanva.Instance.AudioTestTutorial.SetActive(true);

                if (isTyping)
                {
                    currentAudioSource.Stop();
                    DOTween.Complete(DialogueCanvas.Instance.dialogText);
                }
                else
                {
                    DisplayDialogueLine();
                }
                break;
            case DialogueEventType.NameCallingTutorial:
                TutoralCanva.Instance.AudioTestTutorial.SetActive(false);
                TutoralCanva.Instance.NameCallingTutorial.SetActive(true);

                if (isTyping)
                {
                    currentAudioSource.Stop();
                    DOTween.Complete(DialogueCanvas.Instance.dialogText);
                }
                else
                {
                    DisplayDialogueLine();
                }
                break;
            case DialogueEventType.PhotoTutorial:
                TutoralCanva.Instance.NameCallingTutorial.SetActive(false);
                TutoralCanva.Instance.PhotoTutorial.SetActive(true);

                if (isTyping)
                {
                    currentAudioSource.Stop();
                    DOTween.Complete(DialogueCanvas.Instance.dialogText);
                }
                else
                {
                    DisplayDialogueLine();
                }
                break;
            case DialogueEventType.TempTutorial:
                TutoralCanva.Instance.PhotoTutorial.SetActive(false);
                TutoralCanva.Instance.TempTutorial.SetActive(true);

                if (isTyping)
                {
                    currentAudioSource.Stop();
                    DOTween.Complete(DialogueCanvas.Instance.dialogText);
                }
                else
                {
                    DisplayDialogueLine();
                }
                break;
            case DialogueEventType.PhysicsTutorial:
                TutoralCanva.Instance.TempTutorial.SetActive(false);
                TutoralCanva.Instance.PhysicsTutorial.SetActive(true);

                if (isTyping)
                {
                    currentAudioSource.Stop();
                    DOTween.Complete(DialogueCanvas.Instance.dialogText);
                }
                else
                {
                    DisplayDialogueLine();
                }
                break;
            case DialogueEventType.ComputerTutorial:
                TutoralCanva.Instance.PhysicsTutorial.SetActive(false);
                TutoralCanva.Instance.ComputerTutorial.SetActive(true);

                if (isTyping)
                {
                    currentAudioSource.Stop();
                    DOTween.Complete(DialogueCanvas.Instance.dialogText);
                }
                else
                {
                    DisplayDialogueLine();
                }
                break;
            case DialogueEventType.BellTutorial:
                TutoralCanva.Instance.ComputerTutorial.SetActive(false);
                TutoralCanva.Instance.BellTutorial.SetActive(true);

                if (isTyping)
                {
                    currentAudioSource.Stop();
                    DOTween.Complete(DialogueCanvas.Instance.dialogText);
                }
                else
                {
                    DisplayDialogueLine();
                }
                break;
            case DialogueEventType.SubmitTutorial:
                TutoralCanva.Instance.BellTutorial.SetActive(false);
                TutoralCanva.Instance.SubmitTutorial.SetActive(true);

                if (isTyping)
                {
                    currentAudioSource.Stop();
                    DOTween.Complete(DialogueCanvas.Instance.dialogText);
                }
                else
                {
                    DisplayDialogueLine();
                }
                break;
            case DialogueEventType.EndTutorial:
                TutoralCanva.Instance.SubmitTutorial.SetActive(false);
                GameController.Instance.targetCanva.SetActive(true);
                if (isTyping)
                {
                    currentAudioSource.Stop();
                    DOTween.Complete(DialogueCanvas.Instance.dialogText);
                }
                else
                {
                    DisplayDialogueLine();
                }
                break;
            default:
                if (isTyping)
                {
                    currentAudioSource.Stop();
                    DOTween.Complete(DialogueCanvas.Instance.dialogText);
                }
                else
                {
                    DisplayDialogueLine();
                }
                break;
        }
    }
}
