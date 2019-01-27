using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadHouse : MonoBehaviour {
    
    private Transform player;
    private Transform house;

    private void Start() {
        player = Player.instance.transform;
        house = transform.Find("house");
    }

    void Update() {
        
        if (player.position.x - house.position.x < 0)
            if (!house.gameObject.activeSelf)
                house.gameObject.SetActive(true);
        else 
            if (house.gameObject.activeSelf)
                house.gameObject.SetActive(false);
        
    }
    
}
