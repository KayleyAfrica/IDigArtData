using UnityEngine;

public class TechDoors : Interactable
{
    public GameObject door;
    bool isOpen;

    protected override void Interact()
    {
        isOpen = !isOpen;   
        door.gameObject.GetComponent<Animator>().SetBool("isOpen", isOpen);        
    }
}