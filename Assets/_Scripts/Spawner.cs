using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, ITakeDamage {

    public float spawnWait = 3f;

    public GameObject prefab;
    public Vector3 range = Vector3.zero;
    
    private void Start() {
        StartCoroutine(Spawn());
    }

    //only relevant if spawner is destroyable
    public void TakeDamage(float damage) {
        
    }

    IEnumerator Spawn() {

        while (true) {

            Vector3 spawnPos = transform.position;
            spawnPos += new Vector3(Random.Range(-range.x, range.x), Random.Range(-range.y, range.y),
                Random.Range(-range.z, range.z));

            Instantiate(prefab, spawnPos, Quaternion.identity);
            
            yield return new WaitForSeconds(spawnWait);

        }
        
        
    }
    
    
}
