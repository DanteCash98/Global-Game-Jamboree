using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMove : MonoBehaviour {

    private Vector3 velocity;
    private Animator anim;

    public float runSpeed = 2;
    public float runAcceleration = 0.01f;

    [FormerlySerializedAs("fallAcceleration")] 
    public Vector3 gravity = new Vector3(0, -10, 0);
    public float jumpForce = 500;
    private Rigidbody2D rb;
    private int maxJumps = 3;
    private int jumpsUsed = 0;
    private bool jumping = false;
    [FormerlySerializedAs("dashSpeed")] 
    [SerializeField] private float dashCooldown;
    [SerializeField] private float dashTime;
    [SerializeField] private float dashCoolDown;
    [SerializeField] private float currentDashCooldown;
    bool dashing;
    private int direction;
    private float timeOnCurrentDash;
    [SerializeField] private int dashCounter = 0;
    [SerializeField] private float timeGrounded = 0;

    public bool slow;

    
    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        direction = 1;
        timeOnCurrentDash = dashTime;
    }

    private void Update() {
        Run();
        Dash();
        Jump();
    }

    void Run() {
        
        if (GetInput.Forward()) {
            GetComponent<SpriteRenderer>().flipX = true;
            float xVelocity = Mathf.Clamp(velocity.x + runAcceleration * Time.deltaTime, 0, runSpeed);
            velocity = velocity.WithValues(x: xVelocity);
            anim.SetBool("Running", true);
            direction  = 1;
    
        } else if (GetInput.Back()) {
            GetComponent<SpriteRenderer>().flipX = false;
            float xVelocity = Mathf.Clamp(velocity.x - runAcceleration * Time.deltaTime, -runSpeed, 0);
            velocity = velocity.WithValues(x: xVelocity);
            anim.SetBool("Running", true);
            direction = -1;
        }
        else {
            velocity = velocity.Lerp(Vector3.zero, Time.deltaTime * 3);
            anim.SetBool("Running", false);
        }
        
        transform.Translate(velocity * Time.deltaTime);    

    }

    private void Jump() {
        anim.SetBool("Jumping", true);
        Vector3 velocity = GetVerticalMovement(gravity);
        rb.AddForce(velocity);
    }

    private void Dash()
    {

        if(GetInput.Dash() && CanDash())
        {
            if(direction == 1)
            {
                 rb.velocity = Vector2.right * dashCooldown;
            }
            else if(direction == -1)
            {
                
                 rb.velocity = Vector2.left * dashCooldown;
            }
            dashing = true;
            currentDashCooldown = dashCoolDown;
            if(jumpsUsed > 0)
                dashCounter++;
        }
        else
        {
            if(dashing)
            {
                timeOnCurrentDash -= Time.deltaTime;
            }
            else
            {
                if(currentDashCooldown >= 0)
                    currentDashCooldown -= Time.deltaTime;
            }

            if(timeOnCurrentDash <= 0)
            {
                rb.velocity = Vector2.left * 0;
                timeOnCurrentDash = dashTime;
                dashing = false;
            }
        }

    }

    private bool CanDash()
    {
        return (currentDashCooldown <= 0 && ((jumpsUsed > 0 && dashCounter == 0) || jumpsUsed == 0));
    }  
    //adds _force to velocity
    public Vector3 GetVerticalMovement(Vector3 acc) {
        
        if (jumpsUsed >= maxJumps)
            return acc;
        
        if (GetInput.Up()) {
            jumpsUsed++;
            timeGrounded = 0;
            rb.velocity = Vector3.zero;
            jumping = true;
            return acc + new Vector3(0,jumpForce);
        }

        return acc;

    }
    
    float originalSpeed;
    float originalAcceleration;
    float originalDashCooldown;
    Vector3 originalGravity;

    public IEnumerator Slow(float scalar, float duration) {

        if (!slow) {

            originalSpeed = runSpeed;
            originalAcceleration = runAcceleration;
            originalDashCooldown = dashCooldown;
            originalGravity = gravity;
            
            slow = true;
            
            runSpeed /= scalar;
            runAcceleration /= scalar;
            dashCooldown *= scalar;
            gravity *= scalar;
        }

        yield return new WaitForSeconds(duration);

        slow = false;
        
        runSpeed = originalSpeed;
        runAcceleration = originalAcceleration;
        dashCooldown = originalDashCooldown;
        gravity = originalGravity;

    }

    private void OnCollisionStay2D(Collision2D other) {
        
        if(other.gameObject.layer != 9)
            return;
    
        anim.SetBool("Jumping", false);
        timeGrounded += Time.time;

        

    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        //check if other is the ground
        // not a platform
        
        if(other.gameObject.layer != 9)
            return;
        
        if (other.gameObject.layer == 9 && other.gameObject.transform.position.y  > transform.position.y +  transform.localScale.y)
           return; 
        

        OnLanded();

    }

   

    private void OnLanded() {
        anim.SetBool("Jumping", false);
        dashCounter = 0;
        jumpsUsed = 0;
    }
}
