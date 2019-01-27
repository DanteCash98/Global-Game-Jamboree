using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeapon : MonoBehaviour
{
    private void Start() {
        if (GetComponent<MeshRenderer>() != null)
            GetComponent<MeshRenderer>().sortingLayerName = "Foreground";
    }

    void OnTriggerEnter2D(Collider2D other) {
        //Debug.Log(other.name);
       // Debug.Log(other.GetComponent<ITakeDamage>());
        if (other.GetComponent<ITakeDamage>() != null) {
            other.GetComponent<ITakeDamage>().TakeDamage(10);
        }
        if(other.gameObject.layer == 13 || other.gameObject.layer == 14)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
