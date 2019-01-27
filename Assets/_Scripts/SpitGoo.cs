using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitGoo : MonoBehaviour, IInteractable {
    
    private PlayerMove player;
    
    void Start() {
        player = Player.instance.GetComponent<PlayerMove>();
    }
    
    public void Interact() {
        //player.
    }
}
