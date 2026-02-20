using Unity.Cinemachine;
using UnityEngine;

public class PCManager : MonoBehaviour
{
    [SerializeField] private CinemachineCamera computerCamera;
    [SerializeField] private CinemachineCamera playerCamera;

    [Header("UI component")]
    [SerializeField] private GameObject errorAllContent;
    [SerializeField] private GameObject header;
    [SerializeField] private GameObject footer;


    [SerializeField] private GameObject mainMenuContent;
    [SerializeField] private GameObject reportContent;
    [SerializeField] private GameObject testContent;
    [SerializeField] private GameObject helpContent;
    [SerializeField] private GameObject body;

    private void Start()
    {
        playerCamera = PlayerController.Instance.playerCinemachineCamera;
        ShowMainMenu();
    }

    public void ExitToComputer()
    {
        playerCamera.gameObject.SetActive(true);
        CanvaManager.Instance.gameObject.SetActive(true);
        computerCamera.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenComputer()
    {
        playerCamera.gameObject.SetActive(false);
        CanvaManager.Instance.gameObject.SetActive(false);
        computerCamera.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void ShowMainMenu()
    {
        HideAll();

        body.SetActive(true);
        header.SetActive(true);
        footer.SetActive(true);
        mainMenuContent.SetActive(true);
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
}
