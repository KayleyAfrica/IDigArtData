using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    Zombie zombie;
    private float range = 3f;
    [SerializeField]
    private LayerMask mask;
    void Start()
    {
        zombie = FindObjectOfType<Zombie>();
    }


    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction, Color.blue);
        if(Physics.Raycast(ray, out hit, range, mask))
        {
            Vector3 newDirection = Vector3.Cross(hit.normal, transform.forward);
            zombie.agent.SetDestination(newDirection + transform.position *  range);
        }
    }
}
