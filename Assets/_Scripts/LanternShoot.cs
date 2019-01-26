using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternShoot : MonoBehaviour {
    
    public Transform light;
    private Transform player;

    public static Vector3 lanternScaler = new Vector3(15,15,15);
    private Vector3 startScale;

    private void Start() {
        player = Player.instance.transform;
        startScale = light.localScale;
    }

    private void Update() {
        
        light.transform.LookAt(player.position);

        if (Input.GetKeyDown(KeyCode.J)) {
      //      StartCoroutine(Fire());
            Fire();
        }
        
    }

    private void Fire() {
        Debug.Log("Fired!");
    }
/*
    IEnumerator Fire() {

        while (light.localScale != lanternScaler) {
            Vector3 scale = light.localScale;
            scale = Vector3.Lerp(scale, lanternScaler, 5f);
            light.localScale = scale;
            yield return null;
        }
        
        yield return new WaitForSeconds(.1f);

        light.localScale = startScale;


    }
*/
    
}
