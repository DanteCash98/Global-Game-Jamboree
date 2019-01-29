using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    //all available mememtos in game
    public enum Mememto {Shovel, Axe};
    public List<Mememto> collectedMememtos;
    
    #region singleton
    
    public static Player instance { get; private set; }
    
    private void Awake() {

        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            collectedMememtos = new List<Mememto>();
        }
        
    }
    
    #endregion

    public bool invulnerable = false;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        MonoBehaviour other = col.gameObject.GetComponent<MonoBehaviour>();
        if(other is IInteractable)
        {
            IInteractable interactable = other as IInteractable;
            interactable.Interact();
        }
    }   

    public List<Mememto> GetMememtos()
    {
        return collectedMememtos;
    }

}
