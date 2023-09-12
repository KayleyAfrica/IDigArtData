using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
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

        if (Vector3.Distance(transform.position, player.position) <= SearchRange)
        {
            Vector3 direction = player.position - transform.position;
            Ray ray = new Ray(transform.position, direction.normalized);
            Debug.DrawRay(ray.origin, ray.direction * SearchRange, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, SearchRange))
            {
                if (hit.transform.CompareTag("Player"))
                {
                    agent.SetDestination(player.position);

                    if (Vector3.Distance(transform.position, player.position) <= ChaseRange)
                    {
                        isSearching = false; // Stop searching when chasing
                                             // Attack or perform chase behavior
                        agent.SetDestination(player.position);
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
            // Set a random destination within a certain range
            randomDestination = transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            agent.SetDestination(randomDestination);

            wanderTimer = 0f;
        }
    }

}
