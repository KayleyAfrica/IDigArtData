using UnityEngine;

public class LightSwitch : Interactable
{
    public Light bulb;
    protected override void Interact()
    {
        bulb.enabled = !bulb.enabled;
    }
}
