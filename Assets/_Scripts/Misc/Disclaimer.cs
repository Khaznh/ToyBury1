using DG.Tweening;
using UnityEngine;

public class Disclaimer : MonoBehaviour
{
    private void Start()
    {
        PlayFadeSequence();
    }

    public CanvasGroup targetCanvasGroup;

    public void PlayFadeSequence()
    {
        targetCanvasGroup.alpha = 0f;

        Sequence mySequence = DOTween.Sequence();

        mySequence.AppendInterval(1f);

        mySequence.Append(targetCanvasGroup.DOFade(1f, 1f));

        mySequence.AppendInterval(4f);

        mySequence.Append(targetCanvasGroup.DOFade(0f, 1f));

        mySequence.OnComplete(ChangeToMenuScene);
    }

    private void ChangeToMenuScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuScene");
    }
}
