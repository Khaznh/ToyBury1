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

    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToSetting()
    {
        mainPackage.SetActive(false);
        optionPackage.SetActive(true);
    }

    public void GoToMain()
    {
        mainPackage.SetActive(true);
        optionPackage.SetActive(false);
    }

    public void PlayGame()
    {
        Color c = hideOutImage.color;
        c.a = 0;
        hideOutImage.color = c;

        Sequence se = DOTween.Sequence();

        DOTween.To(() => mainCamera.Lens.FieldOfView,
                       x => {
                           var lens = mainCamera.Lens;
                           lens.FieldOfView = x;
                           mainCamera.Lens = lens;
                       },
                       0.1f, 0.75f).SetEase(Ease.InQuad);

        hideOutImage.DOFade(1f, 0.5f)
        .SetEase(Ease.InQuad)
        .OnComplete(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        });
    }
}
