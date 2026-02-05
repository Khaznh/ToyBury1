using Unity.Cinemachine;
using UnityEngine;

public class PCItem : Item
{
    public override void Interact()
    {
        GetComponent<PCManager>().OpenComputer();
    }
}
