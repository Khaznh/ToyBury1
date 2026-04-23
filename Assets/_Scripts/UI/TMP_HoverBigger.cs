using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TMP_HoverBigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI text;
    private float _originalFontSize;
    private Tween _sizeTween;

    [SerializeField] private float hoverScale = 1.2f;

    public void OnPointerEnter(PointerEventData eventData)
    {
        AnimateFontSize(_originalFontSize * hoverScale);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        AnimateFontSize(_originalFontSize);
    }

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        _originalFontSize = text.fontSize;
    }

    private void OnDisable()
    {
        _sizeTween?.Kill();
    }

    private void AnimateFontSize(float targetSize)
    {
        _sizeTween?.Kill();

        _sizeTween = DOTween.To(() => text.fontSize,
                                x => text.fontSize = x,
                                targetSize,
                                0.25f)
                            .SetEase(Ease.OutQuad);
    }
}
