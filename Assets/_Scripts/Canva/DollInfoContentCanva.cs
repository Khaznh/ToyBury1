using TMPro;
using UnityEngine;

public class DollInfoContentCanva : MonoBehaviour
{
    public TextMeshProUGUI dollName;
    public TextMeshProUGUI dollOwner;
    public TextMeshProUGUI dollDescription;

    public GameObject boxCorrect;
    public GameObject boxIncorrect;
    public GameObject testCorrect;
    public GameObject testIncorrect;

    public void Init(Doll doll)
    {
        TurnOffAll();
        Debug.Log("Name: " + doll.dollSO.dollName);
        dollName.text = doll.dollSO.dollName;
        dollOwner.text = doll.dollSO.dollOwner;
        dollDescription.text = doll.dollSO.dollStory;

        if (doll.dollTestStatus.isTestCorrect)
        {
            testCorrect.SetActive(true);
        } else
        {
            testIncorrect.SetActive(true);
        }

        if (doll.dollTestStatus.isTypeCorrect)
        {
            boxCorrect.SetActive(true);
        } else
        {
            boxIncorrect.SetActive(true);
        }
    }

    private void TurnOffAll()
    {
        boxCorrect.SetActive(false);
        boxIncorrect.SetActive(false);
        testCorrect.SetActive(false);
        testIncorrect.SetActive(false);
    }
}
