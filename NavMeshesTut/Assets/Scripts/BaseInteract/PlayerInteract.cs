using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera Cam;
    PlayerUI playerUI;
    private float Range = 50f;
    [SerializeField]
    private LayerMask mask;
    void Start()
    {
        Cam = GetComponent<Camera>();
        playerUI = FindObjectOfType<PlayerUI>();
    }


    void Update()
    {
        playerUI.UpdateTxt(string.Empty);
        Ray ray = new Ray (Cam.transform.position, Cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction, Color.yellow);
        RaycastHit hit;
        if(Physics.Raycast (ray, out hit, Range))
        {
            if(hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                playerUI.UpdateTxt (interactable.promptMessage);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.BaseInteract();
                }
            }
        }
    }
}
