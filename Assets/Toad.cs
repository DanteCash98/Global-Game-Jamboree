using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : MonoBehaviour, ITakeDamage {

    public float health = 100f;

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }
    
    public void TakeDamage(float damage) {
        health -= damage;

        if (health <= 0)
            Die();

    }

    public void SpitGoo() {
        
        anim.SetTrigger("Spit");
        
    }

    public void SpitWater() {
        
    }

    private void Die() {
        
    }
    
}
