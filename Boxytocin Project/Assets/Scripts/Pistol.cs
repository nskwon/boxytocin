using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 10;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    private AudioSource shootSound;
    private void Start()
    {
        shootSound = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(transform.parent.tag == "Player1" && Input.GetButtonDown("Fire1")){
            StartCoroutine(Shoot());
        }
	    else if(transform.parent.tag == "Player2" && Input.GetButtonDown("Fire2")){
            StartCoroutine(Shoot());
	    }
    }

    IEnumerator Shoot()
    {
        //Shooting logic
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        
        if(hitInfo)
        {
	    
            Debug.Log("Hit Object");
            if(hitInfo.collider.tag == "Hittable" || hitInfo.collider.tag == "Player1" || hitInfo.collider.tag == "Player2")
            {
                Debug.Log("Take Damage");
		        hitInfo.transform.SendMessageUpwards("takeDamage", damage);
            }
            //Instantiate(impactEffect, hitInfo.point, Quaternion.identity);
            lineRenderer.SetPosition(0, firePoint.position);
            Debug.Log("Line sent out");
            lineRenderer.SetPosition(1, hitInfo.point);
            Debug.Log("Position set");
            shootSound.Play();
        }

        else
        {
            lineRenderer.SetPosition(0, firePoint.position);                   
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
            shootSound.Play();
        }

        lineRenderer.enabled = true;

        //wait one frame
        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;

    }

}
