using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class CanvaManager : Singleton<CanvaManager>
{
    public TextMeshProUGUI notiText;
    public TextMeshProUGUI useText;
    public TextMeshProUGUI dangerText;

    [SerializeField] private NotiTextSO interact;
    [SerializeField] private NotiTextSO use;

    private Coroutine useTextCoroutine;
    private Coroutine dangerTextCoroutine;

    public override void Awake()
    {
        base.Awake();

        if (notiText == null || useText == null || dangerText == null)
        {
            Debug.Log("CanvaManager variables is not found");
        }
    }

    public void ShowText(InteractableType interactableType)
    {
        foreach (var entry in interact.entries)
        {
            if (entry.key == interactableType)
            {
                notiText.text = entry.value;
                notiText.gameObject.SetActive(true);
                return;
            }
        }
    }

    public void ShowUseText(InteractableType interactableType)
    {
        if (useTextCoroutine != null)
        {
            StopCoroutine(useTextCoroutine);
        }

        useTextCoroutine = StartCoroutine(ShowUseTextRoutine(interactableType));
    }

    private IEnumerator ShowUseTextRoutine(InteractableType interactableType)
    {
        foreach (var entry in use.entries)
        {
            if (entry.key == interactableType)
            {
                useText.text = entry.value;
                useText.gameObject.SetActive(true);
            }
        }

        Color color = useText.color;
        color.a = 1f;
        useText.color = color;

        yield return new WaitForSeconds(3f);

        float fadeDuration = 1f;
        float t = 0f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            useText.color = color;
            yield return null;
        }

        useText.gameObject.SetActive(false);
        useTextCoroutine = null;
    }

    private IEnumerator ShowDangerTextRoutine(string message)
    {
        dangerText.text = message;
        dangerText.gameObject.SetActive(true);
        Color color = dangerText.color;
        color.a = 1f;
        dangerText.color = color;
        yield return new WaitForSeconds(3f);
        float fadeDuration = 1f;
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, t / fadeDuration);
            dangerText.color = color;
            yield return null;
        }
        dangerText.gameObject.SetActive(false);
        dangerTextCoroutine = null;
    }

    public void HideUseTextImmediate()
    {
        if (useTextCoroutine != null)
        {
            StopCoroutine(useTextCoroutine);
            useTextCoroutine = null;
        }

        if (useText != null)
        {
            Color color = useText.color;
            color.a = 1f;
            useText.color = color;

            useText.gameObject.SetActive(false);
        }
    }

    public void ShowDangerText(string message)
    {
        HideDangerText();

        StartCoroutine(ShowDangerTextRoutine(message));
    }

    public void HideDangerText()
    {
        if (dangerTextCoroutine != null)
        {
            StopCoroutine(dangerTextCoroutine);
            dangerTextCoroutine = null;
        }

        if (dangerText != null)
        {
            Color color = dangerText.color;
            color.a = 1f;
            dangerText.color = color;

            dangerText.gameObject.SetActive(false);
        }
    }

    public void HideText()
    {
        notiText.gameObject.SetActive(false);
    }
}
