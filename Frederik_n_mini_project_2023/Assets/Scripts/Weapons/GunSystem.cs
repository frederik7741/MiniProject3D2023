using System.Collections;
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    // Gun stats
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    public int bulletsLeft, bulletsShot;

    // Booleans for shooting and reloading
    bool shooting, readyToShoot, reloading;

    // References
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    // CamShake and UI text references
    public CamShake camShake;
    public float camShakeMagnitude, camShakeDuration;
    // public TextMeshProUGUI text;

    // Set initial conditions
    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }

    // Update is called once per frame
    private void Update()
    {
        MyInput();
    }

    // Handle player input
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        // Check for reload input
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) Reload();

        // Shoot when conditions are met
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
        }
    }

    // Execute the shooting mechanics
    private void Shoot()
    {
        readyToShoot = false;

        // Spread calculation
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        // Calculate direction with spread
        Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

        // Raycast to detect enemies
        if (Physics.Raycast(fpsCam.transform.position, direction, out rayHit, range, whatIsEnemy))
        {
            Debug.Log(rayHit.collider.name);

            // Call EnemyDie() on the enemy if hit
            if (rayHit.collider.CompareTag("Enemy"))
                rayHit.collider.GetComponent<EnemyAttack>().EnemyDie();
        }

        // Shake the camera
        StartCoroutine(camShake.Shake(camShakeDuration, camShakeMagnitude));

        // Update bullets and invoke necessary methods
        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    // Reset readyToShoot flag after cooldown
    private void ResetShot()
    {
        readyToShoot = true;
    }

    // Reload the weapon
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    // Finish reloading and update bulletsLeft
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}
