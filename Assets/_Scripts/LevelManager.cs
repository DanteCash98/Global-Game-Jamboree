using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    #region singleton

    public static LevelManager instance { get; private set; }

    private float fadeTime = 1.0f;
    public Image BlackScreen;

    private void Awake(){
        if (instance != null){
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
        //DontDestroyonLoad(gameObject);
    }

    #endregion

    public void CallSceneCoroutine(int index){
        StartCoroutine("SceneFade", index);
    }

    private IEnumerator SceneFade(/*string scenename*/ int index){
        //string _scenename = scenename;
        int idx = index;
        //DisableControls
        yield return null;
        
        BlackScreen = GetComponent<Image>();
        Debug.Log(BlackScreen == null);
        for (float timePassed = 0; timePassed < fadeTime; timePassed += Time.deltaTime){
            Color tempColor = BlackScreen.color;
            tempColor.a = Mathf.Lerp(0.0f, 1.0f, timePassed);
            BlackScreen.color = tempColor;
            yield return null;
        }
        SceneManager.LoadScene(/*_scenename*/ idx, LoadSceneMode.Single);
        yield return null;

        BlackScreen = GetComponent<Image>();
        for (float timePassed = 0; timePassed < fadeTime; timePassed += Time.deltaTime){
            Color tempColor = BlackScreen.color;
            tempColor.a = Mathf.Lerp(1.0f, 0.0f, timePassed);
            BlackScreen.color = tempColor;
            yield return null;
        }
        
        //EnableControls
    }
}
