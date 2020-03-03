using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    private int health;

    public HealthSystem(int health)
    {
        this.health = health;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
    }

}
