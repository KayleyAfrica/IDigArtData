using UnityEngine;

public class PlayeInteract : MonoBehaviour
{
    PlayerUI playerUI;
    Camera cam;

    [SerializeField]
    private LayerMask mask;
    public float range;

    void Start()
    {
        playerUI = FindObjectOfType<PlayerUI>();
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        playerUI.UpdateTxt(string.Empty);

        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * range, Color.cyan);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, range))
        {
            if(hit.collider.GetComponent<Interactable>() != null)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                playerUI.UpdateTxt(interactable.promptMessage);

                if(Input.GetKeyDown(KeyCode.E))
                {
                    interactable.BaseInteract();
                }
            }
        }

    }
}
