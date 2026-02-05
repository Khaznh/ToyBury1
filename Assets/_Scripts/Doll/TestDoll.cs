using UnityEngine;

public class TestDoll : Doll     
{
    protected override void InteractWithTempuration()
    {
        base.InteractWithTempuration();

        Debug.Log("AAAAAAAAAAAAAAAAAAAA");
    }

    protected override void InteractWithScissor()
    {
        base.InteractWithScissor();


    }
}
