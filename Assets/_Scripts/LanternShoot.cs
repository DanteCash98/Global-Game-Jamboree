using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternShoot : MonoBehaviour {
    
    public Transform light;
    private Transform player;

    public Vector3 lanternScaler;

    private void Start() {
        player = Player.instance.transform;
    }

    private void Update() {
        
        light.transform.LookAt(player.position);

        if (Input.GetKeyDown(KeyCode.J)) {
            StartCoroutine(Fire());
        }
        
    }

    IEnumerator Fire() {

        light.localScale *= 2;
        
        yield return new WaitForSeconds(.1f);

        light.localScale /= 2;

    }

    
}
