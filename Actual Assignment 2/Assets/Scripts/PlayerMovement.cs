using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10f;
    public float jump = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

       if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
        }

        

    }
}
