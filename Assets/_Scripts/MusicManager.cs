﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    
    #region singleton
    public static MusicManager instance { get; private set; }
    public AudioSource MainSource;
    public AudioSource LayerSource;
    private bool paused;

    private float fullVol = 1.0f;
    private float noVol = 0.0f;
    private float fadeTime = 1.0f;
    private float mainMixVol = 0.7f;
    private float layerMixVol = 0.4f;

    private void Awake(){
     MainSource = GetComponent<AudioSource>();
        paused = false;
        if (instance != null){
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
        DontDestroyonLoad(gameObject);
    }

    #endregion

    public void Play(String name){
     MainSource.clip = Resources.Load<AudioClip>(name);
     MainSource.Play();
    }

    public void Stop(){
     MainSource.Stop();
    }
    
    // public void onMenu(){
    //     paused = !paused;
    //     if (paused){
    //         MainSource.volume /= 2;
    //     } else {
    //         MainSource.volume *= 2;
    //     }
    // }

    private IEnumerator MusicSwap(String songname){
        String _songname = songname;
        yield return null;

        for (float timePassed = 0; timePassed < fadeTime; timePassed += Time.deltaTime){
            float vol = Mathf.Lerp(fullVol, noVol, timePassed);
         MainSource.volume = vol;

            yield return null;
        }

        yield return new WaitForSeconds(0.5f);

     MainSource.Stop();
     MainSource.clip = Resources.Load<AudioClip>(_songname);
     MainSource.Play();

        for (float timePassed = 0; timePassed < fadeTime; timePassed += Time.deltaTime){
            float vol = Mathf.Lerp(noVol, fullVol, timePassed);
         MainSource.volume = vol;

            yield return null;
        }
    }

    private IEnumerator MusicLayer(String songname){
        String _songname = songname;
        yield return null;

        for (float timePassed = 0; timePassed < fadeTime; timePassed += Time.deltaTime){
            float mainVol = Mathf.Lerp(fullVol, mainMixVol, timePassed);
            float layerVol = Mathf.Lerp(noVol, layerMixVol, timePassed);
            //Alternatively, fade out main and fade in layer 100% for crossfade
            MainSource.volume = mainVol;
            LayerSource.volume = layerVol;

            yield return null;
        }
    }
}
