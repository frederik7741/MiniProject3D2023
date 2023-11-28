using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public Text speedText;
    public Text healthText;
    public Text ammo;
    public PlayerHealth playerHealth; // Reference to the PlayerHealth script

    private Rigidbody playerRigidbody;
    public GunSystem gunSystem;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        
        if (playerHealth == null)
        {
            playerHealth = GetComponent<PlayerHealth>();
        }

        if (speedText == null || healthText == null)
        {
            Debug.LogError("SpeedText or HealthText not assigned in the inspector!");
        }
    }

    void Update()
    {
        // Calculate and display the player's speed

        float speed = playerRigidbody.velocity.magnitude;
        speedText.text = "Speed: " + speed.ToString("F2") + " m/s";
        // Display current health and ammo

        healthText.text = "Health: " + playerHealth.currentHealth.ToString();
        ammo.text = "Ammo: " + gunSystem.magazineSize/6 + "/" + gunSystem.bulletsLeft/6;
    }
}
