using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public TMP_Text healthTxt;
    void Start()
    {
        health = 10;
    }

    void Update()
    {
        healthTxt.text = "Health: " + health.ToString();
    }
}
