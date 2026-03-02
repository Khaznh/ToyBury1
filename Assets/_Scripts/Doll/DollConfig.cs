using UnityEngine;

[CreateAssetMenu(menuName = "Game/Doll Data")]
public class DollConfig : ScriptableObject
{
    public string dollName;
    public string dollOwner;
    public string dollStory;
    public Sprite dollAvatar;
    public Sprite dollPicure;
    public DollStatus dollStatus;
}

public enum DollStatus
{
    Unsafe,
    Safe
}