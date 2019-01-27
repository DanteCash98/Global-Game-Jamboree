using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grub : MonoBehaviour, ITakeDamage
{
    public float speed = 2f;
    public float health = 30f;

    private float startYPos;

    public void Crunch()
    {
       // startYPos = transform.position.y;
       // StartCoroutine(move());
        
        Vector3 targetPos = (Random.value > .5f) ? 
            transform.right.WithValues(y: transform.position.y): 
            -transform.right.WithValues(y: transform.position.y);
        
        transform.Translate(targetPos);
    }

    IEnumerator move()
    {
    
        Vector3 targetPos = (Random.value > .5f) ? 
            transform.right.WithValues(y: transform.position.y): 
            -transform.right.WithValues(y: transform.position.y);
        
        while (transform.position != targetPos)
        {
            
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
