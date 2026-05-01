using TMPro;
using UnityEngine;

public class DollCountCanva : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dollCount;

    private void Update()
    {
        if (GameController.Instance.dollsToCheck.Count + 1 >= 10)
        {
            dollCount.text = $"000{GameController.Instance.dollsToCheck.Count + 1}";
        } else
        {
            dollCount.text = $"0000{GameController.Instance.dollsToCheck.Count + 1}";
        }
    }
}
