using Unity.Cinemachine;
using UnityEngine;

public class PCManager : MonoBehaviour
{
    [SerializeField] private CinemachineCamera computerCamera;
    [SerializeField] private CinemachineCamera playerCamera;

    private void Start()
    {
        playerCamera = PlayerController.Instance.playerCinemachineCamera;
    }

    public void ExitToComputer()
    {
        playerCamera.gameObject.SetActive(true);
        CanvaManager.Instance.gameObject.SetActive(true);
        computerCamera.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OpenComputer()
    {
        playerCamera.gameObject.SetActive(false);
        CanvaManager.Instance.gameObject.SetActive(false);
        computerCamera.gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }
}
