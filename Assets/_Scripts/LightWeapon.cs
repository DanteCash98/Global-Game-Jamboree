using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeapon : MonoBehaviour
{
    private void Start() {
        if (GetComponent<MeshRenderer>() != null)
            GetComponent<MeshRenderer>().sortingLayerName = "Foreground";
    }

    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<ITakeDamage>() != null) {
            other.GetComponent<ITakeDamage>().TakeDamage(1);
        }
    }
}
