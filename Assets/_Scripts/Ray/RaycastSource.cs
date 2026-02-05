using UnityEngine;

public class RaycastSource : Singleton<RaycastSource>
{
    public InteractableObject currentObject;
    [SerializeField] private float interactDistance = 3f;

    private CanvaManager canvaManager;

    public override void Awake()
    {
        base.Awake();
        canvaManager = CanvaManager.Instance;
    }

    private void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        bool hitInteractable = false;

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            if (hit.collider.CompareTag("InteractableObject"))
            {
                InteractableObject obj = hit.collider.GetComponent<InteractableObject>();
                CanvaManager.Instance.ShowText(obj.interactableType);
                currentObject = obj;
                hitInteractable = true;
            }
        }

        if (!hitInteractable)
        {
            canvaManager.HideText();
            currentObject = null;
        }
    }
}
