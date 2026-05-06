using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    [Header("Light Trigger")]
    [SerializeField] private List<LightTriggerEntity> lightTriggerEntities;

    [Header("Audio")]
    public AudioSource playerAudioSource;
    public AudioSource endGameSource;
    public AudioSource backgroundSource;

    public AudioClip end1Clip;
    public AudioClip end2Clip;

    public AudioEventSO backgroundSO;

    [Header("Door")]
    public bool mainDoorOpen = false;

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
    public Sprite untickSource;

    private int andyTestCount = 0;
    private int andyEscapeMaxCount = 2;

    public Vector3 trash = new Vector3(22.332f, 0.317f, 3.03f);

    [SerializeField] private DialogueSO endGameDialogue;

    public void StartEnd1Music()
    {
        backgroundSO.RaiseEvent(end1Clip, backgroundSource);
    }

    public void StartEnd2Music()
    {
        backgroundSO.RaiseEvent(end2Clip, backgroundSource);
    }

    //For condition
    public void ResetCondition()
    {
        isCallName = false;
        isTempuration = false;
        isScissor = false;
        isCallName = false;
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

        // Andy
        if (currentDoll.GetComponent<Doll>().dollSO.dollName == "Andy" && playerDesition == DollStatus.Unsafe)
        {
            andyTestCount++;
            if (andyTestCount < andyEscapeMaxCount)
            {
                ((Andy)currentDoll.GetComponent<Doll>()).Tele();
                Debug.Log("Andy escaped! try again.");
                return;
            }
        }

        if (currentDoll.GetComponent<Doll>().dollSO.dollStatus == playerDesition || currentDoll.GetComponent<Doll>().dollSO.dollStatus == DollStatus.Both)
        {
            currentDoll.GetComponent<Doll>().dollTestStatus.isTypeCorrect = true;
        }
        else
        {
            currentDoll.GetComponent<Doll>().dollTestStatus.isTypeCorrect = false;
        }

        currentDoll.GetComponent<Doll>().dollTestStatus.isTestCorrect = IsPlayerTestCorrect();
        currentDoll.transform.SetParent(null);
        currentDoll.transform.position = trash;

        if (PlayerPrefs.GetInt(currentDoll.GetComponent<Doll>().dollID.ToString(),0) == 0)
        {
            int hasDoneCount = PlayerPrefs.GetInt("DollHasDone", 0);
            PlayerPrefs.SetInt("DollHasDone", hasDoneCount);
        }

        if (paperIns != null)
        {
            Destroy(paperIns);
        }

        PlayerPrefs.SetInt(currentDoll.GetComponent<Doll>().dollID.ToString(), 1); // 1 for Already tested
        PlayerPrefs.SetInt(currentDoll.GetComponent<Doll>().dollID.ToString() + "_isTypeCorrect", currentDoll.GetComponent<Doll>().dollTestStatus.isTypeCorrect ? 1 : 0); // 1 for true, 0 for false
        PlayerPrefs.SetInt(currentDoll.GetComponent<Doll>().dollID.ToString() + "_isTestCorrect", IsPlayerTestCorrect() ? 1 : 0); // 1 for true, 0 for false
        PlayerPrefs.Save();
        ResetCondition();
        dollsHasDone.Add(currentDoll);
        dollsToCheck.RemoveAt(0);
        currentDoll = null;

        //Sep bao
        if (dollsToCheck.Count == 0)
        {
            DialogueManager.Instance.StartDialogue(endGameDialogue, endGameSource);
            return;
        }
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
    public void SpawnInvestigationSession(GameObject spawnDoll = null)
    {
        if (currentDoll != null)
        {
            CanvaManager.Instance.ShowDangerText("You have not finished your previous assignment.");
            return;
        }

        //Chay cutsceen
        if (dollsToCheck.Count == 0)
        {
            Debug.Log("End");
            SetPlayerControl(false);
            SetPlayerCursor(true);
            EndGameCanvas.Instance.ShowEndGame();
            return;
        }

        if (spawnDoll != null)
        {
            currentDoll = spawnDoll;
            currentDoll.transform.position = spawnPointForDoll.position;

        }
        else
        {
            currentDoll = Instantiate(dollsToCheck[0], spawnPointForDoll.position, spawnPointForDoll.rotation);
        }

        dollTestResult = currentDoll.GetComponent<Doll>().dollSO.testResults;
        SaveData();

        if (paperIns != null)
        {
            Destroy(paperIns);
        }
        storyPaper.GetComponent<StoryPaperCanva>().UpdateStoryPaper(currentDoll.GetComponent<Doll>().dollSO);
        paperIns = Instantiate(paperPrefab, spawnPointForPaper.position, spawnPointForPaper.rotation);
    }

    private void SaveData()
    {
        PlayerPrefs.SetFloat("PlayerPosX", ResetItemManager.Instance.player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", ResetItemManager.Instance.player.transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", ResetItemManager.Instance.player.transform.position.z);

        PlayerPrefs.SetFloat("TempurationPosX", ResetItemManager.Instance.tempuration.transform.position.x);
        PlayerPrefs.SetFloat("TempurationPosY", ResetItemManager.Instance.tempuration.transform.position.y);
        PlayerPrefs.SetFloat("TempurationPosZ", ResetItemManager.Instance.tempuration.transform.position.z);

        PlayerPrefs.SetFloat("ScissorPosX", ResetItemManager.Instance.scissor.transform.position.x);
        PlayerPrefs.SetFloat("ScissorPosY", ResetItemManager.Instance.scissor.transform.position.y);
        PlayerPrefs.SetFloat("ScissorPosZ", ResetItemManager.Instance.scissor.transform.position.z);

        PlayerPrefs.SetFloat("FlashlightPosX", ResetItemManager.Instance.flashlight.transform.position.x);
        PlayerPrefs.SetFloat("FlashlightPosY", ResetItemManager.Instance.flashlight.transform.position.y);
        PlayerPrefs.SetFloat("FlashlightPosZ", ResetItemManager.Instance.flashlight.transform.position.z);

        PlayerPrefs.Save();
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

    public void ForceToTurnOff()
    {
        foreach (var entity in lightTriggerEntities)
        {
            entity.ForceTurnOff();
        }
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
