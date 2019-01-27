using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRandom : MonoBehaviour {

    public bool x, y, z;

    public bool continuous;

    public float rotateWait;
    public float radius;

    void Start() {

        if (continuous) {
            StartCoroutine(RotateContinuous());
        }
        else {
            transform.Rotate(GetRotation());
        }
        
        
    }

    private Vector3 GetRotation() {
        
        Vector3 rotation = new Vector3();

        if (x) {
            rotation.x = Random.Range(-radius, radius);
        }
        if (y) {
            rotation.y = Random.Range(-radius, radius);
        }
        if (z) {
            rotation.z = Random.Range(-radius, radius);
        }

        return rotation;

    }

    IEnumerator RotateContinuous() {

        while (true) {

            Quaternion rotation = Quaternion.Euler(GetRotation());

            while (transform.rotation != rotation) {
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime);
                yield return null;
            }

            yield return null;

        }
        
    }

}
