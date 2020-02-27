using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private bool canMove;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal1");
        movement.y = Input.GetAxisRaw("Vertical1");
        canMove = CheckCollisions(box, movement, 0.05f);
    }

    private void FixedUpdate()
    {
        if (canMove)
        {
            movement.x = 0;
            movement.y = 0;
        }
        else
        {

            if (movement.x != 0 && movement.y != 0)
            {
                rb.MovePosition(rb.position + movement * (moveSpeed * 0.7f) * Time.fixedDeltaTime);
            }
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        }
    }

    private bool CheckCollisions(Collider2D moveCollider, Vector2 direction, float distance)
    {
        if(moveCollider != null)
        {
            RaycastHit2D[] hits = new RaycastHit2D[10];
            ContactFilter2D filter = new ContactFilter2D() { };

            int numHits = moveCollider.Cast(direction, filter, hits, distance);
            for(int i = 0;i < numHits; i++)
            {
                if (!hits[i].collider.isTrigger)
                {
                    return true;
                }
            }
        }
        return false;
    }

}
