using DG.Tweening;
using UnityEngine;

public class BlinksCanvas : MonoBehaviour
{
    [Header("UI Elements")]
    public CanvasGroup blinkOverlay;

    [Header("Settings")]
    public float transitionDuration = 5f;
    
    public AudioSource mainMusic;

    private void PlayEyeBlink(int count, float speed)
    {
        Sequence blinkSeq = DOTween.Sequence();

        for (int i = 0; i < count; i++)
        {
            blinkSeq.Append(blinkOverlay.DOFade(1, speed).SetEase(Ease.InSine)); 
            blinkSeq.Append(blinkOverlay.DOFade(0, speed).SetEase(Ease.OutSine)); 
        }
    }

    private void StartDollTransition()
    {

        PlayEyeBlink(3, 1f);
    }

    public void Test()
    {
        StartDollTransition();
    }
}
