using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSens = 350f;
    private float xRot = 0;
    public Transform player;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * mouseSens;
        var mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * mouseSens;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);
        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        player.Rotate(Vector3.up * mouseX);
    }
}
