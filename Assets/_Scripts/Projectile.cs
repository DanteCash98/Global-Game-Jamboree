using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
    
    public float speed;

    private void Start() {
        GetComponent<MeshRenderer>().sortingLayerName = "Particles";
        transform.position = transform.position.WithValues(z: 0);
    }

    void Update() {
        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
    
}
