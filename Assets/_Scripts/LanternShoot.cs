using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternShoot : MonoBehaviour {
    
    public Transform light;
    private Transform player;

    public GameObject projectile;

    public static Vector3 lanternScaler = new Vector3(4,6,4);
    private Vector3 startScale;

    private AudioSource mySource;

    private void Start() {
        player = Player.instance.transform;
        startScale = light.localScale;
        mySource = GetComponent<AudioSource>();
    }

    private void Update() {
        
        light.transform.LookAt(player.position.WithValues(y:player.position.y - .1f));
        //light.transform.rotation = Quaternion.Euler(light.transform.rotation.eulerAngles.WithValues(x: 0));

        if (Input.GetKeyDown(KeyCode.J)) {
            mySource.Play();
            StartCoroutine(FireAnim());
        }
        
    }

    private void Fire() {

        Instantiate(projectile, light.position, light.rotation);

    }
    
    IEnumerator FireAnim() {

        while (light.localScale != lanternScaler) {
            Vector3 scale = light.localScale;
            scale = Vector3.Lerp(scale, lanternScaler, 1f);
            light.localScale = scale;
            yield return null;
        }
        
        
        Fire();
        
        yield return new WaitForSeconds(.1f);

        light.localScale = startScale;


    }
    
}
