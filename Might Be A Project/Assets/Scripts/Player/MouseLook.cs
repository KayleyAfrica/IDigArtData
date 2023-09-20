using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float mouseSens = 100f;
    private float xRotation = 0;
    private Transform player;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation =Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }
}
