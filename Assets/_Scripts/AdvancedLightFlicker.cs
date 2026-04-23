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

    [SerializeField] private MeshRenderer targetRenderer;
    [SerializeField] private Material matOn;
    [SerializeField] private Material matOff;
    [SerializeField] private int materialIndex = 1;
    [SerializeField] private float materialThreshold = 0.5f;

    private void Start()
    {
        if (targetLight == null) targetLight = GetComponent<Light>();
        if (targetRenderer == null) targetRenderer = GetComponentInChildren<MeshRenderer>();

        StartCoroutine(LightRoutine());
    }

    IEnumerator LightRoutine()
    {
        while (true)
        {
            UpdateMaterial(matOn);
            targetLight.intensity = normalIntensity;
            yield return new WaitForSeconds(Random.Range(minStayOnTime, maxStayOnTime));

            float elapsed = 0f;
            while (elapsed < flickerDuration)
            {
                float newIntensity = Random.Range(flickerIntensity, normalIntensity);
                targetLight.intensity = newIntensity;

                float lerpValue = Mathf.InverseLerp(flickerIntensity, normalIntensity, newIntensity);
                UpdateMaterial(lerpValue > materialThreshold ? matOn : matOff);

                float flickerSpeed = Random.Range(0.01f, 0.1f);
                elapsed += flickerSpeed;
                yield return new WaitForSeconds(flickerSpeed);
            }

            if (Random.value < blackoutChance)
            {
                targetLight.intensity = 0;
                UpdateMaterial(matOff);

                yield return new WaitForSeconds(Random.Range(1f, 3f));

                UpdateMaterial(matOn);
                targetLight.DOIntensity(normalIntensity, 0.5f).SetEase(Ease.OutExpo);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }

    private void UpdateMaterial(Material newMat)
    {
        if (targetRenderer == null || newMat == null) return;

        Material[] mats = targetRenderer.sharedMaterials;
        if (mats.Length > materialIndex)
        {
            if (mats[materialIndex] != newMat)
            {
                mats[materialIndex] = newMat;
                targetRenderer.sharedMaterials = mats;
            }
        }
    }
}