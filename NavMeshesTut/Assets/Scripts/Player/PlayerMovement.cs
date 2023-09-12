using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    public CharacterController controller;
    public float JumpForce = 3f;

    //Gravity Vars
    private float gravity = -9.81f;
    private float distance = .4f;
    [SerializeField]
    private LayerMask mask;
    private bool isGrounded;
    private Vector3 velocity;
    public Transform groundCheck;

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.transform.position, distance, mask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        var H = Input.GetAxis("Horizontal");
        var V = Input.GetAxis("Vertical");
        velocity.y += gravity * Time.deltaTime;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(JumpForce * -2f * gravity);
        }
        controller.Move(velocity * Time.deltaTime);
        Vector3 move = transform.right * H + transform.forward * V;
        controller.Move(move * Time.deltaTime * speed);
    }
}
