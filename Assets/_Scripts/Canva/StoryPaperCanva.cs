using TMPro;
using UnityEngine;

public class StoryPaperCanva : MonoBehaviour
{
    public TextMeshProUGUI dollName;
    public TextMeshProUGUI dollOwner;
    public TextMeshProUGUI dollStory;

    public void UpdateStoryPaper(DollConfig dollConfig)
    {
        dollName.text = dollConfig.dollName;
        dollOwner.text = dollConfig.dollOwner;
        dollStory.text = dollConfig.dollStory;
    }
}
