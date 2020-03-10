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
        if(transform.parent.tag == "Player1" && Input.GetButtonDown("Fire1")){
            Shoot();
        }
	else if(transform.parent.tag == "Player2" && Input.GetButtonDown("Fire2")){
	    Shoot();
	}
    }

    void Shoot()
    {
        //Shooting logic
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        
        if(hitInfo)
        {
	    
            if(hitInfo.collider.tag == "Hittable" || hitInfo.collider.tag == "Player1" || hitInfo.collider.tag == "Player2")
            {
		hitInfo.transform.SendMessageUpwards("takeDamage", damage);
            }
            Instantiate(impactEffect, hitInfo.point, Quaternion.identity);

        }
        
    }

}
