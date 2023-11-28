using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Maximum health and current health variables
    public int maxHealth = 3;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        // Set the player's initial health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // You can add other update logic here if needed
    }

    // Function to be called when the player is hit by the enemy
    public void TakeDamage()
    {
        // Decrease the player's health
        currentHealth--;

        // Check if the player's health is depleted
        if (currentHealth <= 0)
        {
            // Output current health and initiate the death process
            Debug.Log(currentHealth);
            Die();
        }
    }

    // Function to handle player death
    void Die()
    {
        Debug.Log("Reloading the scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}