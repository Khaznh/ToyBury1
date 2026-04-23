using UnityEngine;
using UnityEngine.UI;

public class Canva3D : MonoBehaviour
{
    [SerializeField] private Button clickedB;

    private void Awake()
    {
        clickedB.onClick.AddListener(() => Debug.Log("Clicked"));
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
