using System.Collections;
using Unity.Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PCManager : Singleton<PCManager>
{
    [SerializeField] private CinemachineCamera computerCamera;
    [SerializeField] private CinemachineCamera playerCamera;

    [SerializeField] private GameObject dollCategoryPrefap;
    [SerializeField] private DollConfig chooseDoll;

    [Header("SFX")]
    [SerializeField] private AudioEventSO sfxChannel;
    [SerializeField] private AudioSource computerAudioSource;
    [SerializeField] private AudioClip audioTestTheme;

    [Header("UI component")]
    [SerializeField] private GameObject errorAllContent;
    [SerializeField] private GameObject testAllContent;
    [SerializeField] private GameObject header;
    [SerializeField] private GameObject footer;


    [SerializeField] private GameObject mainMenuContent;
    [SerializeField] private GameObject reportContent;
    [SerializeField] private GameObject testContent;
    [SerializeField] private GameObject helpContent;
    public GameObject dollInfoContent;
    [SerializeField] private GameObject body;

    [SerializeField] private GameObject reportDollList;

    private void Start()
    {
        playerCamera = PlayerController.Instance.playerCinemachineCamera;
        ShowMainMenu();
    }

    public void TryGoToRunTest()
    {
        if (GameController.Instance.IsDollOnChair())
        {
            ShowTestScreen();
        }
        else
        {
            ShowErrorScreen();
        }
    }

    public void RunningTest()
    {
        HideAll();
        body.SetActive(false);
        testAllContent.SetActive(true);
        sfxChannel.RaiseEvent(audioTestTheme, computerAudioSource);
        GameController.Instance.isTestAudio = true;
        GameController.Instance.sitTranForNorSit.GetComponentInChildren<Doll>().InteractWithDoll(InteractableType.Music);
        StartCoroutine(RunningTestCourotine());
    }

    private IEnumerator RunningTestCourotine()
    {
        yield return new WaitForSeconds(audioTestTheme.length);
        GameController.Instance.isInAudioTest = false;
        testAllContent.SetActive(false);
        ShowMainMenu();
    }

    public void ExitToComputer()
    {
        playerCamera.gameObject.SetActive(true);
        CanvaManager.Instance.gameObject.SetActive(true);
        computerCamera.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        GameController.Instance.SetPlayerCursor(false);
    }

    public void OpenComputer()
    {
        playerCamera.gameObject.SetActive(false);
        CanvaManager.Instance.gameObject.SetActive(false);
        computerCamera.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        GameController.Instance.SetPlayerCursor(true);
    }

    public void ShowMainMenu()
    {
        HideAll();

        body.SetActive(true);
        header.SetActive(true);
        footer.SetActive(true);
        mainMenuContent.SetActive(true);

        chooseDoll = null;
    }



    public void ShowErrorScreen()
    {
        HideAll();
        body.SetActive(false);
        errorAllContent.SetActive(true);
    }

    private void HideAll()
    {
        header.SetActive(false);
        footer.SetActive(false);
        mainMenuContent.SetActive(false);
        reportContent.SetActive(false);
        testContent.SetActive(false);
        helpContent.SetActive(false);
        errorAllContent.SetActive(false);
    }

    public void ShowReportScreen()
    {
        HideAll();
        header.SetActive(true);
        footer.SetActive(true);
        reportContent.SetActive(true);

        LoadTestedDoll();
    }

    public void ShowTestScreen()
    {
        HideAll();
        header.SetActive(true);
        footer.SetActive(true);
        testContent.SetActive(true);
    }

    public void ShowHelpScreen()
    {
        HideAll();
        header.SetActive(true);
        footer.SetActive(true);
        helpContent.SetActive(true);
    }

    public void ShowDollInfoContentCanva()
    {
        HideAll();

        header.SetActive(true);
        footer.SetActive(true);
        dollInfoContent.SetActive(true);
    }

    private void LoadTestedDoll()
    {
        int child = reportDollList.transform.childCount;
        for (int i = 0; i < child; i++)
        {
            Destroy(reportDollList.transform.GetChild(i).gameObject);
        }
        
        foreach(GameObject doll in GameController.Instance.dollsHasDone)
        {
            DollCategory dollCategory = Instantiate(dollCategoryPrefap, reportDollList.transform).GetComponent<DollCategory>();
            dollCategory.dollHolder = doll.GetComponent<Doll>();
            dollCategory.nameText.text = doll.GetComponent<Doll>().dollSO.dollName.ToString();
        }
    }

    public void ChooseDollToWatchReport()
    {
        ShowDollInfoContentCanva();
    }
}
