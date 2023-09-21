using UnityEngine;
using UnityEngine.AI;

public class AIAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;

    //range
    private float searchRange = 50f;
    private float detect = 20f;
    private float searchSpeed = 15f;
    private float searchTimer = 0;

    //searches 4 these gameObjects
    private Transform Decoy;
    

    //bools
    bool isSearching = true;

    //Wander randomly
    private float wanderTimer = 0;
    private float wanderInterval = 5f;
    private Vector3 randomDestination;

    //Audio
    public AudioSource voices;
    public AudioClip voice;

    void Update()
    {
        searchTimer += Time.deltaTime;
        if(isSearching && searchTimer <= 5)
        {
            transform.Rotate(Vector3.up * searchSpeed * Time.deltaTime);
        }

        else
        {
            WanderAround();
            //PlayOtherClip();
        }

        if(searchTimer >= 30f)
        {
            searchTimer = 0;
        }

        if(Vector3.Distance(transform.position, player.position) <= searchRange)
        {
            Vector3 direction = player.position - transform.position;
            Ray ray = new Ray(transform.position, direction.normalized);
            Debug.DrawRay(ray.origin, ray.direction * searchRange, Color.yellow);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, searchRange))
            {
                if(hit.transform.tag == "Player")
                {
                    agent.SetDestination(player.position);
                    PlayClip();
                    if (Vector3.Distance(transform.position, player.position)<= detect)
                    {
                        agent.SetDestination(player.position);
                        isSearching = false;    
                    }
                }
            }
        }
        
        if(Decoy != null && Vector3.Distance(transform.position, Decoy.position) <= searchRange)
        {
            Vector3 direction = Decoy.position - transform.position;
            Ray ray = new Ray (transform.position, direction.normalized);
            Debug.DrawRay(ray.origin, ray.direction * searchRange, Color.blue);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, searchRange))
            {       
                if(hit.transform.tag == "Decoy")
                {
                    agent.SetDestination(Decoy.position);
                    if( Vector3.Distance(transform.position, Decoy.position) <= detect)
                    {
                        agent.SetDestination(Decoy.position);
                        isSearching = false;
                    }
                }  
            }
        }
    }

    void WanderAround()
    {
        wanderTimer  += Time.deltaTime;

        if( wanderTimer >= wanderInterval )
        {
            randomDestination = transform.position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            agent.SetDestination(randomDestination);
            wanderTimer = 0;
        }
    }

    public void SetDecoy(Transform newDecoy)
    {
        Decoy = newDecoy;
    }

    public void SetIsSearching(bool value)
    {
        isSearching = value;
    }

    public void PlayClip()
    {
        voices.clip = voice;
        voices.Play();
    }
}
