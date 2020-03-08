using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 10;
    public GameObject impactEffect;
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot()
    {
        //Shooting logic
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        
        if(hitInfo)
        {
            HealthSystem health = hitInfo.transform.GetComponent<HealthSystem>();

            if(health != null)
            {
                health.takeDamage(damage);
            }
            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

        }
        
    }

}
