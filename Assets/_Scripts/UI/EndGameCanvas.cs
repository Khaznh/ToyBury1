using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;

public class EndGameCanvas : Singleton<EndGameCanvas>
{
    [SerializeField] private RectTransform endGameUp;
    [SerializeField] private RectTransform endGameDown;

    [SerializeField] private Vector3 endGameUpDis;
    [SerializeField] private Vector3 endGameUpShow;

    [SerializeField] private Vector3 endGameDownDis;
    [SerializeField] private Vector3 endGameDownShow;

    [SerializeField] private PlayableDirector endGameTimeline;

    public void ShowEndGame()
    {
        Sequence endSeq = DOTween.Sequence();

        endSeq.Join(endGameUp.DOAnchorPos(endGameUpShow, 0.3f).SetEase(Ease.OutBack));
        endSeq.Join(endGameDown.DOAnchorPos(endGameDownShow, 0.3f).SetEase(Ease.OutBack));

        endSeq.OnComplete(() => {
            if (endGameTimeline != null)
            {
                endGameTimeline.Play();
            }
        });
    }

    public void DisableEndGame()
    {
        endGameUp.DOAnchorPos(endGameUpDis, 0.3f).SetEase(Ease.OutBack);
        endGameDown.DOAnchorPos(endGameDownDis, 0.3f).SetEase(Ease.OutBack);
    }
}
