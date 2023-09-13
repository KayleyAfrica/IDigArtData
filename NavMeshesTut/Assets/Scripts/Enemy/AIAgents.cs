using UnityEngine;
using UnityEngine.AI;

public class AIAgents : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public Transform decoy;
    public float SearchRange = 50f;
    public float ChaseRange = 20f;
    public float SearchSpeed = 2f;

    private bool isSearching = true;

    //wanderingg behavior
    private Vector3 randomDestination;
    private float wanderTimer = 0f;
    public float wanderInterval = 5f;

    void Update()
    {


        if (isSearching)
        {
            // Rotate around the Y-axis to search
            transform.Rotate(Vector3.up, SearchSpeed * Time.deltaTime);
        }
        else
        {
            Wander();
        }

        if(Vector3.Distance(transform.position, player.position) <= SearchRange)
        {
            Vector3 direction = player.position - transform.position;
            Ray ray = new Ray(transform.position, direction.normalized);
            Debug.DrawRay(ray.origin, ray.direction * SearchRange, Color.blue);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, SearchRange))
            {
                if (hit.transform.tag == "Player")
                {

                    agent.SetDestination(player.position);
                    if (Vector3.Distance(transform.position, player.position) <= ChaseRange)
                    {
                        isSearching = false;
                        agent.SetDestination(player.position);
                    }
                }
            }
        }

        if (Vector3.Distance(transform.position, decoy.position) <= SearchRange)
        {
            Vector3 direction = decoy.position - transform.position;
            Ray ray = new Ray(transform.position, direction.normalized);
            Debug.DrawRay(ray.origin, ray.direction * SearchRange, Color.red);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, SearchRange))
            {
                if (hit.transform.tag == "Decoy")
                {
                    print("Found it");
                    agent.SetDestination(decoy.position);
                    if (Vector3.Distance(transform.position, decoy.position) <= ChaseRange)
                    {
                        isSearching = false;
                        agent.SetDestination(decoy.position);
                    }
                }
            }
           
        }
    }

    void Wander()
    {
        wanderTimer += Time.deltaTime;

        if (wanderTimer >= wanderInterval)
        {
            // this'll set a random destination within a range
            randomDestination = transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            agent.SetDestination(randomDestination);

            wanderTimer = 0f;
        }
    }
}
