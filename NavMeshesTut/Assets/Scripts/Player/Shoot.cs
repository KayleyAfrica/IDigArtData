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
    public AIAgents[] aiAgent; 

    void Start()
    {

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

            
            foreach (AIAgents aiAgent in aiAgent)
            {
                // Set the decoy for the AI agent
                aiAgent.SetDecoy(Projectile.transform);
                aiAgent.SetIsSearching(false);
            }
        }
    }
}
