using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MenuSceneManager : Singleton<MenuSceneManager>
{
    [SerializeField] private Image hideOutImage;
    [SerializeField] private string sceneName = "TestScene";

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

        se.Append(hideOutImage.DOFade(1f, 1.5f).SetEase(Ease.InQuad));

        se.OnComplete(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        });
    }
}
