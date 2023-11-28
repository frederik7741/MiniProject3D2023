using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyFollow : MonoBehaviour
{
    public NavMeshAgent enemy;
    public Transform Player;
    public float followRadius = 14f;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer <= followRadius)
        {
            enemy.SetDestination(Player.position);
        }
        else
        {
            // Optionally, you can add behavior when the player is outside the follow radius
            // For example, stopping the enemy or performing other actions.
            enemy.ResetPath(); // Stop the enemy
        }
    }
}
