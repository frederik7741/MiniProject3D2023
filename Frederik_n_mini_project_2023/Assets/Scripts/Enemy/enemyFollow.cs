using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyFollow : MonoBehaviour
{
    // Reference to the NavMeshAgent for enemy movement
    public NavMeshAgent enemy;

    // Reference to the player's transform for tracking
    public Transform Player;

    // The radius within which the enemy will start following the player
    public float followRadius = 14f;

    void Update()
    {
        // Calculate the distance between the enemy and the player
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        // Check if the player is within the follow radius
        if (distanceToPlayer <= followRadius)
        {
            // Set the destination for the enemy to follow the player
            enemy.SetDestination(Player.position);
        }
        else
        {
            // If the player is outside the follow radius, stop the enemy
            enemy.ResetPath();
        }
    }
}

