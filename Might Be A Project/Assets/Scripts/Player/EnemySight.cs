using UnityEngine;

public class EnemySight : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float maxSightDistance = 10f; // Maximum distance at which the enemy can see the player
    public LayerMask obstacleLayer; // The layer that represents obstacles

    private void Update()
    {
        // Calculate the direction from the enemy to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Check if the player is within the maximum sight distance
        if (directionToPlayer.magnitude <= maxSightDistance)
        {
            // Perform raycasting to check for obstacles
            Ray ray = new Ray(transform.position, directionToPlayer.normalized);
            RaycastHit hit;

            // Perform the raycast, ignoring the enemy's own collider
            if (Physics.Raycast(ray, out hit, maxSightDistance, ~LayerMask.GetMask("Enemy")))
            {
                // If the ray hits something and that something is not the player,
                // it means there's an obstacle blocking the view
                if (!hit.collider.CompareTag("Player"))
                {
                    // The player is hidden behind an obstacle, and the enemy can't see them
                    // Implement any behavior for when the player is not visible here
                }
                else
                {
                    // The ray hit the player, meaning they are in the enemy's line of sight
                    // Implement behavior for when the player is visible here
                    // For example, you could have the enemy chase or attack the player
                }
            }
        }
        else
        {
            // The player is too far away, and the enemy can't see them
            // Implement behavior for when the player is out of sight range here
        }
    }
}

