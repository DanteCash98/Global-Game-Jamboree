using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grub : MonoBehaviour, ITakeDamage
{
    public float speed = 2f;
    public GameObject player;
    public float health = 30f;

    private float startYPos;

    public void Crunch()
    {
        startYPos = transform.position.y;
        StartCoroutine(move());
    }

    IEnumerator move()
    {
    
        Vector3 targetPos = (Random.value > .5f) ? 
            Vector3.right.WithValues(y: transform.position.y): 
            Vector3.left.WithValues(y: transform.position.y);
        
        while (transform.position != targetPos)
        {

            Mathf.Clamp(transform.position.y, startYPos,startYPos);
            
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * speed);
            yield return null;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SendMessage("AddLight", -0.1f,SendMessageOptions.DontRequireReceiver);
    }

    public void TakeDamage(float damage)
    {
        Destroy(gameObject);
        Debug.Log("Croissant: Damage Taken");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
