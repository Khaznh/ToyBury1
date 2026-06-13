using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DollInfoContentCanva : MonoBehaviour
{
    private Doll doll;

    [SerializeField] private List<GameObject> dollInfo;
    [SerializeField] private List<GameObject> dollStory;

    public Image avatar;
    public TextMeshProUGUI dollName;
    public TextMeshProUGUI dollOwner;
    public TextMeshProUGUI dollDescription;
    public TextMeshProUGUI dollStoryText;

    public GameObject boxCorrect;
    public GameObject boxIncorrect;
    public GameObject testCorrect;
    public GameObject testIncorrect;

    public GameObject dollReadStoryButton;

    public Image dollFace;

    private void OnDisable()
    {
        ToggleResultInfo(false);
    }

    public void Init(Doll doll)
    {
        TurnOffAll();

        this.doll = doll;

        dollReadStoryButton.SetActive(true);

        Debug.Log("Name: " + doll.dollSO.dollName);
        dollName.text = doll.dollSO.dollName;
        dollOwner.text = doll.dollSO.dollOwner;
        dollDescription.text = doll.dollSO.dollStory;
        dollStoryText.text = doll.dollSO.dollReason;
        dollFace.sprite = doll.dollSO.dollAvatar;

        if (doll.dollTestStatus.isTestCorrect)
        {
            testCorrect.SetActive(true);
        }
        else
        {
            testIncorrect.SetActive(true);
        }

        if (doll.dollTestStatus.isTypeCorrect)
        {
            boxCorrect.SetActive(true);
        }
        else
        {
            boxIncorrect.SetActive(true);
        }

        if (doll.dollTestStatus.isTypeCorrect == false || doll.dollTestStatus.isTestCorrect == false)
        {
            dollReadStoryButton.SetActive(false);
        }
    }

    public void ReadResult()
    {
        ToggleResultInfo(true);
    }

    public void RetryDoll()
    {
        if (doll == null)
        {
            return;
        }

        GameController.Instance.SpawnInvestigationSession(doll.gameObject);
        GameController.Instance.dollsHasDone.Remove(doll.gameObject);
        GameController.Instance.dollsToCheck.Insert(0, doll.gameObject);
        PCManager.Instance.ShowMainMenu();
    }

    private void ToggleResultInfo(bool status)
    {
        foreach (var info in dollInfo)
        {
            info.gameObject.SetActive(!status);
        }

        foreach (var info in dollStory)
        {
            info.gameObject.SetActive(status);
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
