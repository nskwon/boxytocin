using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform firePoint;
    public int damage = 10;
    public GameObject impactEffect;
    public LineRenderer lineRenderer;
    public float timeBetweenShots = 0.5f;
    private float timestamp;
    public int maxAmmo = 10;
    public int currentAmmo = -1;
    public float timeBetweenReload = 1.0f;
    public float reloadTime = 3.0f;
    private bool isReloading = false;

    private void Start()
    {
        if(currentAmmo == -1)
        {
            currentAmmo = maxAmmo;
        }

    }
    void Update()
    {

        if (isReloading)
        {
            return;
        }

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }
        if (Time.time >= timestamp && transform.parent.tag == "Player1" && Input.GetButton("Fire1")){
            StartCoroutine(Shoot());
            timestamp = Time.time + timeBetweenShots;
            Debug.Log(currentAmmo);
        }
	    else if(Time.time >= timestamp && transform.parent.tag == "Player2" && Input.GetButton("Fire2")){
            StartCoroutine(Shoot());
            timestamp = Time.time + timeBetweenShots;
	    }
    }

    IEnumerator Shoot()
    {
        //Shooting logic
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        currentAmmo--;
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
            FindObjectOfType<AudioManager>().Play("PistolShoot");
        }

        else
        {
            lineRenderer.SetPosition(0, firePoint.position);                   
            lineRenderer.SetPosition(1, firePoint.position + firePoint.right * 100);
            FindObjectOfType<AudioManager>().Play("PistolShoot");
        }

        lineRenderer.enabled = true;

        //wait one frame
        yield return new WaitForSeconds(0.02f);

        lineRenderer.enabled = false;

    }

    IEnumerator Reload()
    {
        FindObjectOfType<AudioManager>().Play("PistolReload");
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        isReloading = false;
    }

}
