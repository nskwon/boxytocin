using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector2 movement;
    private bool moveUp = false;
    private bool moveDown = false;
    private bool moveRight = false;
    private bool moveLeft = false;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        /*
        if (Input.GetKey(KeyCode.UpArrow))
        {
            moveUp = true;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            moveUp = false;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveLeft = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            moveLeft = false;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            moveDown = true;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            moveDown = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveRight = true;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            moveRight = false;
        }
        */

    }

    private void FixedUpdate()
    {
        if(movement.x != 0 && movement.y != 0)
        {
            rb.MovePosition(rb.position + movement * (moveSpeed * 0.7f) * Time.fixedDeltaTime);
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        /*
        if (moveUp && !moveDown)
        {
            rb.velocity = new Vector2(0, 5.0f);
            if (moveRight)
            {
                rb.velocity = new Vector2(5.0f, 5.0f);
            }
            else if (moveLeft)
            {
                rb.velocity = new Vector2(-5.0f, 5.0f);
            }
        }
        else if()
        else if (moveLeft && !moveRight)
        {
            rb.velocity = new Vector2(-5.0f, 0);
            if (moveUp && !moveRight)
            {
                rb.velocity = new Vector2(-5.0f, 5.0f);
            }
            else if (moveDown && !moveRight)
            {
                rb.velocity = new Vector2(-5.0f, -5.0f);
            }
        }
        else if (moveDown && !moveUp)
        {
            rb.velocity = new Vector2(0, -5.0f);
            if (moveRight)
            {
                rb.velocity = new Vector2(5.0f, -5.0f);
            }
            else if (moveLeft)
            {
                rb.velocity = new Vector2(-5.0f, -5.0f);
            }
        }
        else if (moveRight && !moveLeft)
        {
            rb.velocity = new Vector2(5.0f, 0);
            if (moveUp && !moveLeft)
            {
                rb.velocity = new Vector2(5.0f, 5.0f);
            }
            else if (moveDown && !moveLeft)
            {
                rb.velocity = new Vector2(5.0f, -5.0f);
            }
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
        }
        */
    }
}
