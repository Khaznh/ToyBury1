using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedLightFlicker : MonoBehaviour
{
    [Header("Settings")]
    public Light targetLight;
    public float normalIntensity = 25f;
    public float flickerIntensity = 5f;

    [Header("Timers")]
    public float minStayOnTime = 3f;
    public float maxStayOnTime = 10f;

    public float flickerDuration = 2f;
    public float blackoutChance = 0.3f;

    private void Start()
    {
        if (targetLight == null) targetLight = GetComponent<Light>();

        StartCoroutine(LightRoutine());
    }

    IEnumerator LightRoutine()
    {
        while (true)
        {
            // TRẠNG THÁI 1: Sáng ổn định một lúc lâu
            targetLight.intensity = normalIntensity;
            yield return new WaitForSeconds(Random.Range(minStayOnTime, maxStayOnTime));


            float elapsed = 0f;
            while (elapsed < flickerDuration)
            {

                targetLight.intensity = Random.Range(flickerIntensity, normalIntensity);

                float flickerSpeed = Random.Range(0.01f, 0.1f);
                elapsed += flickerSpeed;
                yield return new WaitForSeconds(flickerSpeed);
            }

            if (Random.value < blackoutChance)
            {
                targetLight.intensity = 0;
                yield return new WaitForSeconds(Random.Range(1f, 3f));

                targetLight.DOIntensity(normalIntensity, 0.5f).SetEase(Ease.OutExpo);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
