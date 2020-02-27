using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector2 movement;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal2");
        movement.y = Input.GetAxisRaw("Vertical2");
    }

    private void FixedUpdate()
    {
        if (movement.x != 0 && movement.y != 0)
        {
            rb.MovePosition(rb.position + movement * (moveSpeed * 0.7f) * Time.fixedDeltaTime);
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}
