using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    [Header("SFX")]
    [SerializeField] private AudioEventSO sfxChannel;

    [SerializeField] private AudioClip audioTestTheme;

    [Header("Chair")]
    public Transform sitTranForCamera;
    public Transform sitTranForNorSit;

    [Header("Doll")]
    public List<Doll> dollsToCheck;
    public Doll currentDoll;

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

    //For PC
    public bool IsDollOnChair()
    {
        if (currentDoll == null)
        {
            return false;
        }

        return sitTranForNorSit.childCount > 0;
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

        if (paperIns != null)
        {
            Destroy(paperIns);
        }
        storyPaper.GetComponent<StoryPaperCanva>().UpdateStoryPaper(currentDoll.GetComponent<Doll>().dollSO);
        paperIns = Instantiate(paperPrefab, spawnPointForPaper.position, spawnPointForPaper.rotation);
        dollsToCheck.RemoveAt(0);
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
