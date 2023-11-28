using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damagePerSecond = 1f;

    private PlayerHealth playerHealth;

    void Start()
    {
        // Find the PlayerHealth script on the player GameObject
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    void OnTriggerStay(Collider other)
    {
        // Check if the collider belongs to the player
        if (other.CompareTag("Player"))
        {
            // Assuming the attack is continuous, you can apply damage each frame the player is in contact with the enemy
            playerHealth.TakeDamage();
        }
    }

    public void EnemyDie()
    {
        Debug.Log("enemy died");
        Destroy(gameObject); // Destroy the enemy GameObject

    }
}