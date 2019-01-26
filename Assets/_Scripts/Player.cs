using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    [SerializeField] List <Mememtos> collectedMememtos;
    #region singleton
    
    public static Player instance { get; private set; }
    
    private void Awake() {

        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            collectedMememtos = new List<Mememtos>();
        }
        
    }
    
    #endregion

    private void OnTriggerEnter(Collider col)
    {
        MonoBehaviour other = col.gameObject.GetComponent<MonoBehaviour>();
        if(other is IInteractable)
        {
            IInteractable interactable = other as IInteractable;
            interactable.Interact();
        }
    }

    public List<Mememtos> GetMememtos()
    {
        return collectedMememtos;
    }

}
