using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    private Transform player;

    [SerializeField] private float lerpSpeed = 1f;
    [SerializeField] private Vector3 offset;

    private void Start() {
        player = Player.instance.transform;
    }

    void Update() {
        
       // Vector3 dir = player.
        transform.position = Vector3.Lerp(transform.position, player.position + offset, Time.deltaTime * lerpSpeed);

        if (GetInput.Forward()) {
            offset.x = -1;
        } else if (GetInput.Back()) {
            offset.x = 1;
        }
        
    } 

    [ContextMenu("Bake Offset")]
    private void BakeOffset() {
        offset = transform.position - player.transform.position;
    }
    
}
