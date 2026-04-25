using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private PlayerInput inputActions;
    private bool isPaused = false;

    [SerializeField] private GameObject pauseCanvas;

    [SerializeField] private GameObject mainPart;
    [SerializeField] private GameObject optionPart;
    [SerializeField] private GameObject audioPart;
    [SerializeField] private GameObject controlPart;

    private void Awake()
    {
        inputActions = new PlayerInput();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.Pause.performed += ctx => TogglePause();
    }

    private void OnDisable()
    {
        inputActions.Player.Pause.performed -= ctx => TogglePause();
        inputActions.Disable();
    }

    private void TogglePause()
    {
        if (!isPaused)
        {
            PauseGame();
        }
        else
        {
            ResumeGame();
        }
    }

    private void PauseGame()
    {
        pauseCanvas.SetActive(true);
        GameController.Instance.targetCanva.SetActive(false);
        GameController.Instance.SetPlayerControl(false);
        GameController.Instance.SetPlayerCursor(true);

        Time.timeScale = 0f;
    }

    public void OpenMain()
    {
        mainPart.SetActive(true);
        optionPart.SetActive(false);
        audioPart.SetActive(false);
        controlPart.SetActive(false);
    }

    public void OpenOption()
    {
        mainPart.SetActive(false);
        optionPart.SetActive(true);
        audioPart.SetActive(false);
        controlPart.SetActive(false);
    }

    public void OpenAudio()
    {
        mainPart.SetActive(false);
        optionPart.SetActive(false);
        audioPart.SetActive(true);
        controlPart.SetActive(false);
    }

    public void OpenControl()
    {
        mainPart.SetActive(false);
        optionPart.SetActive(false);
        audioPart.SetActive(false);
        controlPart.SetActive(true);
    }

    public void ResumeGame()
    {
        GameController.Instance.targetCanva.SetActive(true);
        pauseCanvas.SetActive(false);
        GameController.Instance.SetPlayerControl(true);
        GameController.Instance.SetPlayerCursor(false);

        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
