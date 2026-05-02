using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewDialogue", menuName = "DialogSystem/DialogueData")]
public class DialogueSO : ScriptableObject
{
    public List<DialogueLine> dialogueLines;
}

[System.Serializable]
public struct DialogueLine
{
    public string speakerName;
    public string dialogueText;
    public AudioClip audioClip;
    public List<Answer> answers;
}

[System.Serializable]
public struct Answer
{
    public string answerText;
    public DialogueEventType eventType;
}

public enum DialogueEventType
{
    None,
    WantToSeeTutorial,
    YourJobTutorial,
    AudioTestTutorial,
    NameCallingTutorial,
    PhotoTutorial,
    TempTutorial,
    PhysicsTutorial,
    ComputerTutorial,
    BellTutorial,
    SubmitTutorial,
    EndTutorial,
}
