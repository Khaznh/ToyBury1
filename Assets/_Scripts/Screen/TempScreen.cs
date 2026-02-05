using TMPro;
using UnityEngine;

public class TempScreen : Singleton<TempScreen>
{
    [SerializeField] private TextMeshProUGUI tempText;

    public void ShowTemp(float temp)
    {
        tempText.text = $"{temp} C";
    }
}
