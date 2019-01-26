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

    private void OnTriggerEnter(Collider col)
    {
        GameObject other = col.GetComponent<GameObject>();
        if(other is IInteractable)
        {
            IInteractable interactable = (IInteractable) gameObject.GetComponent(typeof(IInteractable));
            interactable.Interact();
        }
    }
}
