using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponController : MonoBehaviour
{
    public GameObject Crowbar;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (CanAttack)
            {
                CrowbarAttack();
            }
        }
    }

    public void CrowbarAttack()
    {
        CanAttack = false;
        Debug.Log("attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true; // Reset the attack cooldown
    }
}
