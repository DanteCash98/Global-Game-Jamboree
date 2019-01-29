using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toad : MonoBehaviour, ITakeDamage {

    public float health = 100f;

    private float attackCooldown = 1f;

    private Animator anim;
    private Transform gooSpout, waterSpout;
    private AudioSource toadSource;

    public GameObject goo;
    public GameObject water;

    void Start() {
        anim = GetComponent<Animator>();
        gooSpout = transform.Find("Goo Spout");
        waterSpout = transform.Find("Water Spout");
        toadSource = GetComponent<AudioSource>();

        StartCoroutine(Spit());
    }
    
    public void TakeDamage(float damage) {
        
        health -= damage;

        if (health <= 0)
            Die();

    }

    private void OnTakeDamage() {
        
        GetComponent<SpriteRenderer>().color = Color.Lerp(GetComponent<SpriteRenderer>().color, new Color(120, 0, 255), 100 / health);
        
    }
    
    IEnumerator Spit() {


        while (true) {
            
            yield return new WaitForSeconds(Random.Range(attackCooldown / 2, attackCooldown * 2));

            if (Random.value > .6f)
                anim.SetTrigger("SpitGoo");
           // else 
              //  anim.SetTrigger("SpitWater");
            
        }
        
        
    }

    public void SpitGoo() {

        toadSource.Play();
        GameObject instance = Instantiate(goo, gooSpout.position, Quaternion.identity);
        instance.transform.localScale = instance.transform.localScale.WithValues(x: Random.Range(.8f, 1.2f));

    }

    public void SpitWater() {

        Instantiate(water, waterSpout.position, waterSpout.rotation, waterSpout);

    }

    private void Die() {
        anim.SetBool("Dead", true);
    }

    public void OnDied() {
        Destroy(gameObject);
    }
    
}
