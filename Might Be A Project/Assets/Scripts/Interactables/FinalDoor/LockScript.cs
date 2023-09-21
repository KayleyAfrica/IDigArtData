using TMPro;
using UnityEngine;

public class LockScript : MonoBehaviour
{

    public TMP_Text displayUI;
    public int numOfDigits = 0;

    public void Numbers(int num)
    {
        displayUI.text += num.ToString();
        numOfDigits++;
    }
}
