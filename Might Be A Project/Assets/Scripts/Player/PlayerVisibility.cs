using UnityEngine;
using UnityEngine;

public class PlayerVisibility : MonoBehaviour
{
    public LayerMask obstacleLayer; // The layer representing obstacles
    public float fieldOfViewAngle = 90f; // Field of view angle in degrees
    public float maxSightDistance = 10f; // Maximum distance at which the player can be seen

    private Transform playerTransform;
    private bool playerVisible = false;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (IsPlayerVisible())
        {
            // Player is visible
            playerVisible = true;
            // Implement behavior when the player is visible (e.g., change player state)
        }
        else
        {
            // Player is not visible
            playerVisible = false;
            // Implement behavior when the player is not visible
        }
    }

    private bool IsPlayerVisible()
    {
        if (playerTransform == null)
            return false;

        Vector3 directionToPlayer = playerTransform.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer);

        // Check if the player is within the field of view angle
        if (angleToPlayer <= fieldOfViewAngle * 0.5f)
        {
            // Check if the player is within the maximum sight distance
            if (Vector3.Distance(transform.position, playerTransform.position) <= maxSightDistance)
            {
                RaycastHit hit;
                if (Physics.Raycast(transform.position, directionToPlayer, out hit, maxSightDistance, obstacleLayer))
                {
                    // If the raycast hits an obstacle between the enemy and the player, the player is not visible
                    if (!hit.collider.CompareTag("Player"))
                    {
                        return false;
                    }
                }

                // If no obstacles are blocking the view, the player is visible
                return true;
            }
        }

        return false;
    }

    public bool IsPlayerVisibleToEnemy()
    {
        return playerVisible;
    }
}


