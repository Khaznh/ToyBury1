using TMPro;
using UnityEngine;

public class DollCategory : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Doll dollHolder;

    public void ClickDollCategory()
    {
        PCManager.Instance.dollInfoContent.GetComponent<DollInfoContentCanva>().Init(dollHolder);
        PCManager.Instance.ChooseDollToWatchReport();
    }
}
