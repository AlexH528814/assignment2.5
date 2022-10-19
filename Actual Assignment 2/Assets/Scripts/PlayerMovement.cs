using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpGround;


    public float speed = 10f;
    public float jump = 10f;

    public int doublejump = 0;

    private float dirX = 0f;
    
    private enum MovementState {idle, running, jumping }
    private MovementState state = MovementState.idle;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        Debug.Log(dirX);
        
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

       if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            
            
        }
        UpdateAnimationState();
    }   

    private void UpdateAnimationState()
    {
        if (dirX > 0f)
        {
            anim.SetBool("running", true); 
            sprite.flipX = false;
        }

        if (dirX < 0f)
        {
            anim.SetBool("running", true);
            sprite.flipX = true;
        }

        if (dirX == 0f)
        {
            anim.SetBool("running", false);
        }

        if (isGrounded() == false)
        {
            anim.SetBool("jumping", true);
        }

        if (isGrounded() == true)
        {
            anim.SetBool("jumping", false);
        }
    }
    
    private bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpGround);
    }
}
