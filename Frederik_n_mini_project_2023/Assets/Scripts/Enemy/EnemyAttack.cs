using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Damage inflicted on the player per second
    public float damagePerSecond = 1f;

    private PlayerHealth playerHealth;

    // Initialization
    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    // Player collision handling
    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerHealth.TakeDamage();
        }
    }

    // Enemy death handling
    public void EnemyDie()
    {
        Debug.Log("Enemy died");
        Destroy(gameObject);
    }
}