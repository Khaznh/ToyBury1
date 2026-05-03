using DG.Tweening;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneManager : Singleton<MenuSceneManager>
{
    [SerializeField] private Image hideOutImage;
    [SerializeField] private string sceneName = "TestScene";
    [SerializeField] private CinemachineCamera mainCamera;

    [SerializeField] private GameObject mainPackage;
    [SerializeField] private GameObject optionPackage;
    [SerializeField] private GameObject playPackage;

    [SerializeField] private GameObject mainControlCanvas;
    [SerializeField] private GameObject controlOptionCanvas;
    [SerializeField] private GameObject audioOptionCanvas;
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToSetting()
    {
        mainPackage.SetActive(false);
        optionPackage.SetActive(true);

        mainControlCanvas.SetActive(true);
        controlOptionCanvas.SetActive(false);
        audioOptionCanvas.SetActive(false);
    }

    public void GoToAudioSetting()
    {
        mainControlCanvas.SetActive(false);
        audioOptionCanvas.SetActive(true);
    }

    public void GoToControlSetting()
    {
        mainControlCanvas.SetActive(false);
        controlOptionCanvas.SetActive(true);
    }

    public void GoToMain()
    {
        playPackage.SetActive(false);
        mainPackage.SetActive(true);
        optionPackage.SetActive(false);
    }

    public void GotoPlayCanva()
    {
        mainPackage.SetActive(false);
        playPackage.SetActive(true);
    }

    public void PlayNewGame()
    {
        PlayerPrefs.SetInt("NewGame", 1);
        PlayGame();
    }

    public void PlayContinueGame()
    {
        PlayerPrefs.SetInt("NewGame", 0);
        PlayGame();
    }

    private void PlayGame()
    {
        Color c = hideOutImage.color;
        c.a = 0;
        hideOutImage.color = c;

        Sequence se = DOTween.Sequence();

        se.Join(DOTween.To(() => mainCamera.Lens.FieldOfView,
                    x =>
                    {
                        var lens = mainCamera.Lens;
                        lens.FieldOfView = x;
                        mainCamera.Lens = lens;
                    },
                    0.1f, 0.75f).SetEase(Ease.InQuad));

        se.Join(hideOutImage.DOFade(1f, 0.5f).SetEase(Ease.InQuad));

        se.AppendInterval(0.2f);

        se.OnComplete(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        });
    }
}
