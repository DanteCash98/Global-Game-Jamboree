using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpitGoo : MonoBehaviour, IInteractable {
    
    private PlayerMove player;

    public float slowAmount = 3f;
    public float slowDuration = 3f;
    
    void Start() {
        player = Player.instance.GetComponent<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
    }

    public void Interact() {
        StartCoroutine(player.Slow(slowAmount, slowDuration));
    }
}
