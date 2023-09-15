using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform throwingPoint;
    public GameObject projectile;
    public float speed = 20;
    //I created this empty object just so the decoy objects get parented to it
    //that way they don't flood the hierarchy
    //keeps things a bit organised
    public GameObject empty;
    private AIAgents aiAgent; 

    void Start()
    {
        // This Finds the 'AIAgents' script on the AI GameObject
        aiAgent = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AIAgents>();
        // I added this line just in case the above line fails
        aiAgent = FindObjectOfType<AIAgents>();
    }

    void Update()
    {
        // I Used L for now, but anything is fine
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject Projectile = Instantiate(projectile, throwingPoint.position, Quaternion.identity) as GameObject;
            Rigidbody rb = Projectile.GetComponent<Rigidbody>();
            rb.AddForce(throwingPoint.forward * speed, ForceMode.Impulse);
            Projectile.transform.parent = empty.transform;

            // we want to check if the AIAgents script reference is set && is not null
            if (aiAgent != null)
            {
                // Set the decoy for the AI agent
                aiAgent.SetDecoy(Projectile.transform);
            }
        }
    }
}
