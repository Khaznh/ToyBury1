using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    [Header("Result")]
    public TestResult[] dollTestResult;
    public TestResult[] playerResult;

    [Header("Condition")]
    public bool isInAudioTest = false;

    public bool canCallName = false;

    public bool isTestAudio = false;
    public bool isTempuration = false;
    public bool isScissor = false;
    public bool isCallName = false;
    public bool isPhotoTaken = false;

    [Header("Chair")]
    public Transform sitTranForCamera;
    public Transform sitTranForNorSit;

    [Header("Checker")]
    public Transform checkTranForSafe;
    public Transform checkTranForUnSafe;

    [Header("Doll")]
    public List<GameObject> dollsToCheck;
    public List<GameObject> dollsHasDone;
    public GameObject currentDoll;

    public Transform spawnPointForDoll;

    [Header("Canvas")]
    public GameObject targetCanva;
    public GameObject paperCanva;

    [Header("Paper")]
    public GameObject reportPaper;
    public GameObject storyPaper;

    public Transform spawnPointForPaper;
    public GameObject paperPrefab;
    public GameObject paperIns;

    [Header("Other")]
    public FirstPersonMovement firstPersonMovement;
    public FirstPersonLook firstPersonLook;

    public Sprite safeImgSource;
    public Sprite unsafeImgSource;

    //For condition
    public void ResetCondition()
    {
        isCallName = false;
        isTempuration = false;
        isScissor = false;
        isCallName = true;
        isPhotoTaken = false;
    }


    //For PC
    public bool IsDollOnChair()
    {
        if (currentDoll == null)
        {
            return false;
        }

        return sitTranForNorSit.childCount > 0;
    }

    //Test if player test is correct or not
    public bool IsPlayerTestCorrect()
    {
        for (int i = 0; i < playerResult.Length; i++)
        {
            if (playerResult[i] != dollTestResult[i])
            {
                return false;
            }
        }

        return true;
    }

    //For Submit Doll
    public void SubmitDoll(DollStatus playerDesition)
    {
        for (int i = 0; i < playerResult.Length; i++)
        {
            if (playerResult[i] == TestResult.None)
            {
                return;
            }
        }

        if (currentDoll.GetComponent<Doll>().dollSO.dollStatus == playerDesition)
        {
            currentDoll.GetComponent<Doll>().dollTestStatus.isTypeCorrect = true;
        }
        else
        {
            currentDoll.GetComponent<Doll>().dollTestStatus.isTypeCorrect = false;
        }

        currentDoll.GetComponent<Doll>().dollTestStatus.isTestCorrect = IsPlayerTestCorrect();
        currentDoll.gameObject.SetActive(false);
        currentDoll.transform.SetParent(null);

        dollsHasDone.Add(currentDoll);
        dollsToCheck.RemoveAt(0);
        currentDoll = null;
    }

    public bool CanSubmitDoll()
    {
        for (int i = 0; i < playerResult.Length; i++)
        {
            if (playerResult[i] == TestResult.None)
            {
                return false;
            }
        }
        return true;
    }

    // For spawn doll
    public void SpawnInvestigationSession()
    {
        if (currentDoll != null)
        {
            return;
        }

        if (dollsToCheck.Count == 0)
        {
            Debug.Log("No more doll to check");
            return;
        }

        currentDoll = Instantiate(dollsToCheck[0], spawnPointForDoll.position, spawnPointForDoll.rotation);
        dollTestResult = currentDoll.GetComponent<Doll>().dollSO.testResults;
        if (paperIns != null)
        {
            Destroy(paperIns);
        }
        storyPaper.GetComponent<StoryPaperCanva>().UpdateStoryPaper(currentDoll.GetComponent<Doll>().dollSO);
        paperIns = Instantiate(paperPrefab, spawnPointForPaper.position, spawnPointForPaper.rotation);
    }

    // For UI paper
    public void HideAllPaper()
    {
        targetCanva.SetActive(false);
        paperCanva.SetActive(false);

        reportPaper.SetActive(false);
        storyPaper.SetActive(false);
    }

    public void ShowTargetCanva()
    {
        HideAllPaper();

        targetCanva.SetActive(true);
    }

    public void HideTargetCanva()
    {
        targetCanva.SetActive(false);
    }

    public void ShowReportPaper()
    {
        HideAllPaper();

        paperCanva.SetActive(true);
        reportPaper.SetActive(true);
    }

    public void ShowStoryPaper()
    {
        HideAllPaper();

        paperCanva.SetActive(true);
        storyPaper.SetActive(true);
    }

    public bool IsPaperCanvaActive()
    {
        return paperCanva.activeInHierarchy;
    }

    public void SetPlayerControl(bool isEnable)
    {
        firstPersonMovement.enabled = isEnable;
        firstPersonLook.enabled = isEnable;
    }

    public void SetPlayerCursor(bool isEnable)
    {
        if (isEnable)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
