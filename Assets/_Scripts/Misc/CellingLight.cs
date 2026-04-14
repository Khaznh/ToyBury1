using UnityEngine;

public class CellingLight : MonoBehaviour
{
    [SerializeField] private Light _light;
    [SerializeField] private Material offMat;
    [SerializeField] private Material onMat;

    [SerializeField] private MeshRenderer _meshRenderer;

    private void Awake()
    {
        _meshRenderer = GetComponentInChildren<MeshRenderer>();
    }

    public void TurnOn()
    {
        _light.gameObject.SetActive(true);
        Material[] currentMaterials = _meshRenderer.materials;
        currentMaterials[1] = onMat;
        _meshRenderer.materials = currentMaterials;
    }

    public void TurnOff()
    {
        _light.gameObject.SetActive(false);
        Material[] currentMaterials = _meshRenderer.materials;
        currentMaterials[1] = offMat;
        _meshRenderer.materials = currentMaterials;
    }
}
