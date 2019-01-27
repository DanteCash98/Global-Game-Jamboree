using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    private Vector3 velocity;
    private Animator anim;

    public float runSpeed = 2;
    public float runAcceleration = 0.01f;

    public Vector3 fallAcceleration = new Vector3(0, -10, 0);
    public float jumpForce = 500;
    private Rigidbody2D rb;
    private int maxJumps = 3;
    private int jumpsUsed = 0;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        Run();
        Jump();
    }

    void Run() {
        
        if (GetInput.Forward()) {
            GetComponent<SpriteRenderer>().flipX = true;
            float xVelocity = Mathf.Clamp(velocity.x + runAcceleration * Time.deltaTime, 0, runSpeed);
            velocity = velocity.WithValues(x: xVelocity);
            anim.SetBool("Running", true);
        } else if (GetInput.Back()) {
            GetComponent<SpriteRenderer>().flipX = false;
            float xVelocity = Mathf.Clamp(velocity.x - runAcceleration * Time.deltaTime, -runSpeed, 0);
            velocity = velocity.WithValues(x: xVelocity);
            anim.SetBool("Running", true);
        }
        else {
            velocity = velocity.Lerp(Vector3.zero, Time.deltaTime * 3);
            anim.SetBool("Running", false);
        }
        
        transform.Translate(velocity * Time.deltaTime);

    }

    private void Jump() {
        Vector3 velocity = GetVerticalMovement(fallAcceleration);
        rb.AddForce(velocity);
    }

    //adds _force to velocity
    public Vector3 GetVerticalMovement(Vector3 acc) {
        
        if (jumpsUsed >= maxJumps)
            return acc;
        
        if (GetInput.Up()) {
            jumpsUsed++;
            rb.velocity = Vector3.zero;
            return acc + new Vector3(0,jumpForce);
        }

        return acc;

    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        
        //check if other is the ground
        // not a platform
        
        Debug.Log(other.gameObject.layer);
            
        if (other.gameObject.layer != 9)
            return; 
        
        //below platform
      //  if (other.transform.position.y - transform.position.y > 0)
        //    return;

        OnLanded();

    }

    private void OnLanded() {
        jumpsUsed = 0;
    }
}
