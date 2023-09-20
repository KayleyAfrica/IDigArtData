using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed;
    public float walkSpeed;
    public float sprintSpeed;
    public float jumpHeight;
    public CharacterController controller;
    public Camera cam;

    //jump Vars
    private float gravity = -9.81f;
    private float distance = .4f;
    private bool isGrounded;
    private Vector3 velocity;
    [SerializeField]
    private LayerMask mask;
    public Transform groundCheck;

    //States
    public movementState state;
    public enum movementState
    { 
        Walking,
        Sprinting,
    }

    public void StateHandler()
    {
        if(isGrounded && Input.GetKey(KeyCode.LeftShift))
        {
            state = movementState.Sprinting;
            speed = sprintSpeed;
            HeadBobSprint();
        }

        else if(isGrounded)
        {
            state = movementState.Walking;
            speed = walkSpeed;
        }
    }


    void Update()
    {
        //Movement logic
        var H = Input.GetAxis("Horizontal");
        var V = Input.GetAxis("Vertical");

        Vector3 move = transform.right * H + transform.forward * V;
        controller.Move(move * speed * Time.deltaTime);

        //Jump Logic
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //gravity

        isGrounded = Physics.CheckSphere(groundCheck.position, distance, mask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Handles movement States
        StateHandler();

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

    }

    void HeadBobSprint()
    {
        cam.GetComponent<Animator>().SetTrigger("isSprinting");
    }
}
