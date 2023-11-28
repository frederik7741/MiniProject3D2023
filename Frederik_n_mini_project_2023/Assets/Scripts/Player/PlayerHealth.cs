using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
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
        currentHealth--;

        if (currentHealth <= 0)
        {
            Debug.Log(currentHealth);
            Die();
        }
    }

    // Function to handle player death
    void Die()
    {
        // You can add death-related logic here, such as restarting the level or showing a game over screen
        Debug.Log("Reloading the scene...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}