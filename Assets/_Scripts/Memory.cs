using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour, IInteractable {

    public Player.Mememto mememto;

    public GameObject myMemento;

    public void Interact() {
        Player.instance.collectedMememtos.Add(mememto);
        myMemento.SetActive(true);
        Destroy(GetComponent<Animator>());
        GetComponent<SpriteRenderer>().sprite = myMemento.GetComponent<SpriteRenderer>().sprite;
        Invoke("DestroySelf", 1f);
        
    }

    private void DestroySelf() {
        Destroy(gameObject);
    }

}
