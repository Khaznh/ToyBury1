using DG.Tweening;
using TMPro;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gameOverText;

    private void OnEnable()
    {
        StartTyping();
    }

    public void StartTyping()
    {
        gameOverText.alpha = 0;

        Sequence mySequence = DOTween.Sequence();

        mySequence.Append(gameOverText.DOFade(1, 1f).SetEase(Ease.InSine));
        mySequence.Append(gameOverText.DOFade(0, 1f).SetEase(Ease.OutSine));

        mySequence.AppendInterval(1.5f);
    }
}
