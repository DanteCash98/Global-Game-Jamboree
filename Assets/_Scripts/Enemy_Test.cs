using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Test : MonoBehaviour, ITakeDamage
{
    public float health = 1f;

    private void Update()
    {
        
    }
    
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
    
}
