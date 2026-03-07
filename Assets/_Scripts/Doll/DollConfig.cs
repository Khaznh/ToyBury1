using NUnit.Framework;
using UnityEngine;

[CreateAssetMenu(menuName = "Game/Doll Data")]
public class DollConfig : ScriptableObject
{
    public string dollName;
    public string dollOwner;
    public string dollStory;
    public string dollReason;
    public Sprite dollAvatar;
    public Sprite dollPicure;
    public DollStatus dollStatus;

    public TestResult[] testResults = new TestResult[5];
}

public enum DollStatus
{
    Unsafe,
    Safe
}