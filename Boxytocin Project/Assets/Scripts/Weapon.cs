using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damage;
    public float fireRate;
    public float reloadTime;
    public int maxAmmo;

    public Weapon(int damage, float fireRate, float reloadTime, int maxAmmo)
    {
        this.damage = damage;
        this.fireRate = fireRate;
        this.reloadTime = reloadTime;
        this.maxAmmo = maxAmmo;
    }
}
