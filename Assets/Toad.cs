using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : MonoBehaviour, ITakeDamage {

    public float health = 100f;

    private float attackCooldown = 1f;

    private Animator anim;
    private Transform gooSpout, waterSpout;

    public GameObject goo;
    public GameObject water;

    void Start() {
        anim = GetComponent<Animator>();
        gooSpout = transform.Find("Goo Spout");
        waterSpout = transform.Find("Water Spout");

        StartCoroutine(Spit());
    }
    
    public void TakeDamage(float damage) {
        health -= damage;

        if (health <= 0)
            Die();

    }

    IEnumerator Spit() {


        while (true) {
            
            yield return new WaitForSeconds(Random.Range(attackCooldown / 2, attackCooldown * 2));

            if (Random.value > .4f)
                anim.SetTrigger("SpitGoo");
            else 
                anim.SetTrigger("SpitWater");
            
        }
        
        
    }

    public void SpitGoo() {

        GameObject instance = Instantiate(goo, gooSpout.position, Quaternion.identity);
        instance.transform.localScale = instance.transform.localScale.WithValues(x: Random.Range(.5f, 1.5f));

    }

    public void SpitWater() {

        Instantiate(water, waterSpout.position, Quaternion.identity, waterSpout);

    }

    private void Die() {
        
    }
    
}
