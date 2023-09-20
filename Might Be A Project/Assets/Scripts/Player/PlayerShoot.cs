using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform throwPoint;
    public GameObject decoyPrefab;
    private float speed = 15f;

    //Ref To The AIAgent Script
    public AIAgent[] aiAgents;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject decoyObject = Instantiate(decoyPrefab, throwPoint.position, throwPoint.rotation);
            Rigidbody rb = decoyObject.GetComponent<Rigidbody>();

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 targetDirection = (hit.point - throwPoint.position).normalized;
                rb.AddForce(targetDirection * speed, ForceMode.Impulse);
            }
            else
            {
                rb.AddForce(throwPoint.forward * speed, ForceMode.Impulse);
            }

            Destroy(decoyObject, 10f);

            foreach (AIAgent aiAgent in aiAgents)
            {
                aiAgent.SetDecoy(decoyObject.transform);
                aiAgent.SetIsSearching(false);
            }
        }

    }
}
