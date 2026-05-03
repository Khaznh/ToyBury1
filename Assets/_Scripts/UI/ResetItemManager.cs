using UnityEngine;

public class ResetItemManager : Singleton<ResetItemManager>
{
    public GameObject tempuration;
    public GameObject scissor;
    public GameObject flashlight;
    public GameObject player;

    [SerializeField] private Vector3 temPos;
    [SerializeField] private Vector3 scissorPos;
    [SerializeField] private Vector3 flashPos;

    public void ResetItem()
    {
        tempuration.transform.SetParent(null);
        tempuration.transform.position = temPos;

        scissor.transform.SetParent(null);
        scissor.transform.position = scissorPos;

        flashlight.transform.SetParent(null);
        flashlight.transform.position = flashPos;
    }
}
