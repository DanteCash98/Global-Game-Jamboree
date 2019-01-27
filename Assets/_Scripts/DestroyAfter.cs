using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfter : MonoBehaviour {

    public float seconds;
    private AudioSource mySource;
    
    private void Start() {
        mySource = GetComponent<AudioSource>();
        StartCoroutine(DestroyAfterSeconds());
    }

    IEnumerator DestroyAfterSeconds() {
        yield return new WaitForSeconds(seconds);
        mySource.Play();
        Destroy(gameObject);
    }
    
}
