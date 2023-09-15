using UnityEngine;

//This class sets the rigidbody of the decoy object to kinematic on collision
//with gameObjects tagged as 'Wall'

public class BeStill : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
        }
    }
}
