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
    public static int currentAmmoPlayer1 = -1;
    public static int currentAmmoPlayer2 = -1;
    public float timeBetweenReload = 1.0f;
    public float reloadTime = 3.0f;
    private bool isReloading = false;

    private void Start()
    {
        if(currentAmmoPlayer1 == -1 && transform.parent.tag == "Player1")
        {
            currentAmmoPlayer1 = maxAmmo;
        }
        if(currentAmmoPlayer2 == -1 && transform.parent.tag == "Player2")
        {
            currentAmmoPlayer2 = maxAmmo;
        }

    }
    void Update()
    {
        if (!PauseMenu.GameIsPaused && !CountdownHandler.gameOver)
        {
            if (Player1Script.alive && transform.parent.tag == "Player1")
            {

                if (isReloading)
                {
                    return;
                }

                if (currentAmmoPlayer1 <= 0)
                {
                    StartCoroutine(Reload1());
                    return;
                }
                if (Time.time >= timestamp && transform.parent.tag == "Player1" && Input.GetButton("Fire1"))
                {
                    StartCoroutine(Shoot1());
                    timestamp = Time.time + timeBetweenShots;
                    Debug.Log(currentAmmoPlayer1);
                }
                else if (Time.time >= timestamp && transform.parent.tag == "Player2" && Input.GetButton("Fire2"))
                {
                    StartCoroutine(Shoot1());
                    timestamp = Time.time + timeBetweenShots;
                }
            }
            else if(!Player1Script.alive && transform.parent.tag == "Player1")
            {
                refillAmmo1();
                return;
            }

            if (Player2Script.alive && transform.parent.tag == "Player2")
            {

                if (isReloading)
                {
                    return;
                }

                if (currentAmmoPlayer2 <= 0)
                {
                    StartCoroutine(Reload2());
                    return;
                }
                if (Time.time >= timestamp && transform.parent.tag == "Player1" && Input.GetButton("Fire1"))
                {
                    StartCoroutine(Shoot2());
                    timestamp = Time.time + timeBetweenShots;
                    Debug.Log(currentAmmoPlayer2);
                }
                else if (Time.time >= timestamp && transform.parent.tag == "Player2" && Input.GetButton("Fire2"))
                {
                    StartCoroutine(Shoot2());
                    timestamp = Time.time + timeBetweenShots;
                }
            }
            else if (!Player2Script.alive && transform.parent.tag == "Player2")
            {
                refillAmmo2();
                return;
            }
        }
    }

    IEnumerator Shoot1()
    {
        //Shooting logic
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        currentAmmoPlayer1--;
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

    IEnumerator Shoot2()
    {
        //Shooting logic
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);
        currentAmmoPlayer2--;
        if (hitInfo)
        {

            Debug.Log("Hit Object");
            if (hitInfo.collider.tag == "Hittable" || hitInfo.collider.tag == "Player1" || hitInfo.collider.tag == "Player2")
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

    IEnumerator Reload1()
    {
        FindObjectOfType<AudioManager>().Play("PistolReload");
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmoPlayer1 = maxAmmo;
        isReloading = false;
    }

    IEnumerator Reload2()
    {
        FindObjectOfType<AudioManager>().Play("PistolReload");
        isReloading = true;
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmoPlayer2 = maxAmmo;
        isReloading = false;
    }

    public void refillAmmo1()
    {
        currentAmmoPlayer1 = maxAmmo;
    }

    public void refillAmmo2()
    {
        currentAmmoPlayer2 = maxAmmo;
    }

}
