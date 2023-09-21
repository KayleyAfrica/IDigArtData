using UnityEngine;

public class FinalDoor : Interactable
{
    public GameObject uiDisplay;
    public GameObject[] otherUI;

    GameObject door;
    LockScript lockScript;

    private string correctPin = "034753";

    private void Start()
    {
        door = GameObject.FindGameObjectWithTag("FinalDoor");
        lockScript = FindObjectOfType<LockScript>();
    }

    protected override void Interact()
    {
        uiDisplay.SetActive(true);
    }

    private void Update()
    {
        if(uiDisplay.activeSelf)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;

            foreach(var element in otherUI)
            {
                if(element.gameObject.activeSelf)
                {
                    element.gameObject.SetActive(false);
                }             
            }
        }
        else if(!uiDisplay.activeSelf)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            foreach (var element in otherUI)
            {
                if (!element.gameObject.activeSelf)
                {
                    element.gameObject.SetActive(true);
                }
            }
        }  
        
        if(lockScript.numOfDigits >= 6)
        {
            HandleDoorState();
            lockScript.numOfDigits = 0;
        }
    }

    void HandleDoorState()
    {
        if (lockScript.displayUI.text == correctPin)
        {
            door.GetComponent<Animator>().SetTrigger("OpenDoor");
            door.GetComponent<AudioSource>().Play();
            uiDisplay.SetActive(false);
            lockScript.displayUI.text = string.Empty;
        }

        else if(lockScript.displayUI.text != correctPin)
        {
            lockScript.displayUI.text = string.Empty;
        }
    }
}
