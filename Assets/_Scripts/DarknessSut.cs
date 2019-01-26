using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessSut : MonoBehaviour, ITakeDamage {
    
    public GameObject explosionParticle;
    
    public void TakeDamage(float damage) {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}
