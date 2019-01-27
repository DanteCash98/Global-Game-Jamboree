using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessSut : MonoBehaviour, ITakeDamage {
    
    public GameObject explosionParticle;
    private Transform player;

    [SerializeField] private float lerpSpeed = 1f;
    [SerializeField] private Vector3 offset;

    public float range = 10f;

    private float myXClamp;

    private void Start() {
        player = Player.instance.transform;
        myXClamp = Random.Range(-3, 0);
    }

    void Update() {
        // Vector3 dir = player.
        Vector3 rand = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), Random.value);
        transform.position = Vector3.Lerp(transform.position, player.position + offset + rand, Time.deltaTime * lerpSpeed);
        transform.position = transform.position.WithValues(z: 0, x: Mathf.Clamp(transform.position.x, myXClamp, 999f));

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
    
    public void TakeDamage(float damage) {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
}
