using UnityEngine;

public class RaycastSource : Singleton<RaycastSource>
{
    public InteractableObject currentObject;
    
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask nameCallLayerMask;

    private RaycastHit[] hits = new RaycastHit[2];

    private CanvaManager canvaManager;

    public override void Awake()
    {
        base.Awake();
        canvaManager = CanvaManager.Instance;
    }

    private void Update()
    {
        HandleTargetRaycast();
        HandleNameCallTest();
    }

    private void HandleTargetRaycast()
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

    private void HandleNameCallTest()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        int count = Physics.RaycastNonAlloc(ray, hits, 10f, nameCallLayerMask);

        if (count >= 2)
        {
            if (GameController.Instance.sitTranForNorSit.childCount == 0)
            {
                GameController.Instance.canCallName = false;
                return;
            }

            int furthestIndex = -1;

            if (hits[0].distance > hits[1].distance)
            {
                furthestIndex = 0;
            }
            else
            {
                furthestIndex = 1;
            }

            if (!hits[furthestIndex].transform.GetComponentInChildren<Doll>())
            {
                GameController.Instance.canCallName = false;
                return;
            }

            GameController.Instance.canCallName = true;
            return;
        }

        GameController.Instance.canCallName = false;
    }
}
