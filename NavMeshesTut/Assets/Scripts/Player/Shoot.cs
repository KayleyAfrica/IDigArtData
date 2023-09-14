using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform throwingPoint;
    public GameObject projectile;
    public float speed = 20;
    public GameObject empty;
    private AIAgents aiAgent; // Reference to the AIAgents script

    void Start()
    {
        // Find the AIAgents script on the AI GameObject
        aiAgent = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AIAgents>();
        aiAgent = FindObjectOfType<AIAgents>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject Projectile = Instantiate(projectile, throwingPoint.position, Quaternion.identity) as GameObject;
            Rigidbody rb = Projectile.GetComponent<Rigidbody>();
            rb.AddForce(throwingPoint.forward * speed, ForceMode.Impulse);
            Projectile.transform.parent = empty.transform;

            // Check if the AIAgents script reference is set
            if (aiAgent != null)
            {
                // Set the decoy for the AI agent
                aiAgent.SetDecoy(Projectile.transform);
            }
        }
    }
}
