using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    #region singleton

    public static LevelManager instance { get; private set; }

    private float fadeTime = 1.0f;

    private void Awake(){
        if (instance != null){
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
        DontDestroyonLoad(gameObject);
    }

    #endregion

    private IEnumerator SceneFade(String scenename){
        String _scenename = scenename;
        //DisableControls
        yield return null;
        
        //BlackScreen = GetComponent<>();
        for (float timePassed = 0; timePassed < fadeTime; timePassed += Time.deltaTime){
            //BlackScreen.alpha = Mathf.Lerp(1.0f, 0.0f, timePassed);
            yield return null;
        }
        SceneManager.LoadScene(_scenename, LoadSceneMode.Single);
        yield return null;

        //BlackScreen = GetComponent<>();
        for (float timePassed = 0; timePassed < fadeTime; timePassed += Time.deltaTime){
            //BlackScreen.alpha = Mathf.Lerp(0.0f, 1.0f, timePassed);
            yield return null;
        }
        
        //EnableControls
    }
}
