using UnityEngine;

public class FinalDoor : Interactable
{
    GameObject door;
    private void Start()
    {
        door = GameObject.FindGameObjectWithTag("FinalDoor");
    }
    protected override void Interact()
    {
        door.GetComponent<Animator>().SetTrigger("OpenDoor");
        door.GetComponent<AudioSource>().Play();
    }
}
