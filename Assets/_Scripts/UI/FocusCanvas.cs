using UnityEngine;
using DG.Tweening;

public class FocusCanvas : Singleton<FocusCanvas>
{
    [SerializeField] private RectTransform decoUp;
    [SerializeField] private RectTransform decoDown;

    [SerializeField] private Vector3 decoUpDis;
    [SerializeField] private Vector3 decoUpShow;

    [SerializeField] private Vector3 decoDownDis;
    [SerializeField] private Vector3 decoDownShow;

    public void ShowFocus()
    {
        decoUp.DOAnchorPos(decoUpShow, 0.3f).SetEase(Ease.OutBack);
        decoDown.DOAnchorPos(decoDownShow, 0.3f).SetEase(Ease.OutBack);
    }

    public void DisableFocus()
    {
        decoUp.DOAnchorPos(decoUpDis, 0.3f).SetEase(Ease.OutBack);
        decoDown.DOAnchorPos(decoDownDis, 0.3f).SetEase(Ease.OutBack);
    }
}
