using UnityEngine;

public class WarningLight : MonoBehaviour
{
    public float rotateSpeed = 7f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
    }
}
