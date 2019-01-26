using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightWeapon : MonoBehaviour
{
    void OnTriggerEnter(Collider other) {
        if (other.GetComponent<ITakeDamage>() != null) {
            other.GetComponent<ITakeDamage>().TakeDamage(1);
        }
    }
}
