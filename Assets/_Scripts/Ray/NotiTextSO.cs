using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Item Data")]
public class NotiTextSO : ScriptableObject
{
    public List<Entry> entries;
}

[Serializable]
public struct Entry
{
    public InteractableType key;
    public string value;
}