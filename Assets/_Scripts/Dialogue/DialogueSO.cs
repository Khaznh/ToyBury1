using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/DialogueSO")]
public class DialogueSO : ScriptableObject
{
    public List<DialogueNode> dialogueLine;

    public DialogueNode GetNode(string id)
    {
        return dialogueLine.Find(n => n.nodeID == id);
    }
}

[System.Serializable]
public class DialogueNode
{
    public string nodeID;
    public string speakerName; 
    [TextArea(3, 10)]
    public string text;
    public List<Choice> userChoice;
}

[System.Serializable]
public class Choice
{
    public string choiceText;
    public string nextNodeID;
}