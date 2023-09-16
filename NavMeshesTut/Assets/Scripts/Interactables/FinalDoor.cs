using TMPro;
using UnityEngine;

public class FinalDoor : Interactable
{
    public GameObject door;
    public GameObject lockPad;
    public TMP_Text display;
    private string correctPin = "030722";
    private int digitNum = 0;
    protected override void Interact()
    {
        lockPad.SetActive(true);
    }

    private void Update()
    {
        if(lockPad.activeSelf)
        {
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
        }
        else if(!lockPad.activeSelf)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(digitNum >= 6)
        {
            OpenDoor();
            digitNum = 0;
        }
    }

    public void UnlockDoor(int numbers)
    {
        display.text += numbers.ToString();
        digitNum++;
    }

    private void OpenDoor()
    {
        if (display.text == correctPin)
        {
            door.GetComponent<Animator>().SetBool("Open", true);
            lockPad.SetActive(false);
        }

        else
        {
            display.text = string.Empty;
        }
    }
}
