using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform throwingPoint;
    public GameObject projectile;
    public float speed = 20;
    //parents the projectiles, so they don't flood the hierarchy
    public GameObject empty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            GameObject Projectile = Instantiate(projectile, throwingPoint.position, Quaternion.identity) as GameObject;
            Rigidbody rb = Projectile.GetComponent<Rigidbody>();
            rb.AddForce(throwingPoint.forward * speed, ForceMode.Impulse);
            Projectile.transform.parent = empty.transform;
        }
    }
}
