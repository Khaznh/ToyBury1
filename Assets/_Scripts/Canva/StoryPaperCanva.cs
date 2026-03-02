using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryPaperCanva : MonoBehaviour
{
    public TextMeshProUGUI dollName;
    public TextMeshProUGUI dollOwner;
    public TextMeshProUGUI dollStory;
    public Image dollImg;

    public void UpdateStoryPaper(DollConfig dollConfig)
    {
        dollName.text = dollConfig.dollName;
        dollOwner.text = dollConfig.dollOwner;
        dollStory.text = dollConfig.dollStory;
        dollImg.sprite = dollConfig.dollAvatar;
    }
}
