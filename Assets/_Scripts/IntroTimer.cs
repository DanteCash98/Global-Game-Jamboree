using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTimer : MonoBehaviour
{

    private AudioSource mainSource;
    private float timer;
    private bool start;

    // Start is called before the first frame update
    void Start()
    {
        mainSource = GetComponent<AudioSource>();
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 89.454f && !start){
            mainSource.Play();
            start = true;
        }
    }
}
