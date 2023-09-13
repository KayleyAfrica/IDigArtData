using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    AIAgents agents;
    private float range = 3f;
    [SerializeField]
    private LayerMask mask;
    void Start()
    {
        agents = FindObjectOfType<AIAgents>();
    }


    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);
        if(Physics.Raycast(ray, out hit, range, mask))
        {
            Vector3 newDirection = Vector3.Cross(hit.normal, transform.forward);
            agents.agent.SetDestination(newDirection + transform.position *  range);
        }
    }
}
