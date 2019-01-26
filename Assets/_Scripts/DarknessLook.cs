using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessLook : MonoBehaviour {
    
    public Vector3 playerDirection;
    private Vector3 startPos;
    private Transform player;
    public float lookDistance = 0.07f;

    private void Start() {
        player = Player.instance.transform;
        startPos = transform.localPosition;
    }

    void Update() {
        playerDirection = transform.position.DirectionTo(player.position);
        transform.localPosition = playerDirection * lookDistance;
    }
    
}
