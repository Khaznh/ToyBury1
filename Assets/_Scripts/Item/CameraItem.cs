using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraItem : Item
{
    [SerializeField] private Light cameraLight;
    [SerializeField] private float showTime = 3f;
    [SerializeField] private GameObject cameraCanva;

    [Header("Flash Settings")]
    [SerializeField] private float flashIntensityPeak = 8f;
    [SerializeField] private float flashDuration = 0.05f;
    [SerializeField] private float fadeOutDuration = 0.15f;
    [SerializeField] private float originalIntensity = 1f;

    [Header("Spotlight Angle")]
    [SerializeField] private float originalSpotAngle = 30f;
    [SerializeField] private float flashSpotAngle = 90f;
    [SerializeField] private float originalInnerAngle = 15f;
    [SerializeField] private float flashInnerAngle = 60f;

    private bool isTakingPhoto = false;

    public override void Interact()
    {
        base.Interact();

        if (GameController.Instance.sitTranForCamera.childCount == 0)
        {
            return;
        }

        Debug.Log("Camera Clicked");
        if (!isTakingPhoto)
        {
            Debug.Log("Taking Photo");
            StartCoroutine(TakePhotoEffect());
        }
    }

    private IEnumerator TakePhotoEffect()
    {
        isTakingPhoto = true;

        cameraLight.gameObject.SetActive(true);
        cameraLight.intensity = originalIntensity * 0.3f;
        cameraLight.spotAngle = originalSpotAngle;
        cameraLight.innerSpotAngle = originalInnerAngle;
        yield return new WaitForSeconds(0.05f);

        cameraLight.intensity = flashIntensityPeak;
        cameraLight.spotAngle = flashSpotAngle;
        cameraLight.innerSpotAngle = flashInnerAngle;
        yield return new WaitForSeconds(flashDuration);

        float elapsed = 0f;
        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeOutDuration;
            float tCurved = t * t;

            cameraLight.intensity = Mathf.Lerp(flashIntensityPeak, originalIntensity, tCurved);
            cameraLight.spotAngle = Mathf.Lerp(flashSpotAngle, originalSpotAngle, tCurved);
            cameraLight.innerSpotAngle = Mathf.Lerp(flashInnerAngle, originalInnerAngle, tCurved);

            yield return null;
        }

        cameraLight.gameObject.SetActive(false);
        cameraCanva.GetComponent<CameraCanva>().dollPicture.sprite = GameController.Instance.sitTranForCamera.GetComponentInChildren<Doll>().dollSO.dollPicure;
        cameraCanva.SetActive(true);
        yield return new WaitForSeconds(showTime);
        cameraCanva.SetActive(false);
        isTakingPhoto = false;
    }
}
