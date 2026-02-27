using UnityEngine;

public class PlaceTrigger : MonoBehaviour
{
    [SerializeField] private BoxCollider triggerCollider;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlaceEntity placeEntity = GetComponentInParent<PlaceEntity>();
            placeEntity.PlayerEnter();
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlaceEntity placeEntity = GetComponentInParent<PlaceEntity>();
            placeEntity.PlayerExit();
        }
    }
}
