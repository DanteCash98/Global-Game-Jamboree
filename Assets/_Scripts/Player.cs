using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    #region singleton
    
    public static Player instance { get; private set; }
    
    private void Awake() {

        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
        }
        
    }
    
    #endregion
}
