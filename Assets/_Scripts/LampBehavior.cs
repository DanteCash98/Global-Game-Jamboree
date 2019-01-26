using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampBehavior : MonoBehaviour
{
    public float fadeSpeed;
    private Light light;
    private void Start()
    {
        light = GetComponent<Light>();
    }
    
    // Update is called once per frame
    private void Update()
    {

        light.range -= Time.deltaTime * fadeSpeed;
        light.intensity -= Time.deltaTime / fadeSpeed;
    }
}
