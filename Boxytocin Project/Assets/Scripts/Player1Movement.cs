using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private bool cannotMove;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal1");
        movement.y = Input.GetAxisRaw("Vertical1");
        if (movement.x > 0 && movement.y == 0)
        {
            anim.SetBool("Right", true);
        }
        else if (movement.x < 0 && movement.y == 0)
        {
            anim.SetBool("Left", true);
        }
        else if (movement.x == 0 && movement.y > 0)
        {
            anim.SetBool("Up", true);
        }
        else if (movement.x == 0 && movement.y < 0)
        {
            anim.SetBool("Down", true);
        }
        else if (movement.x > 0 && movement.y > 0)
        {
            anim.SetBool("UpRight", true);
        }
        else if (movement.x < 0 && movement.y > 0)
        {
            anim.SetBool("UpLeft", true);
        }
        else if (movement.x < 0 && movement.y < 0)
        {
            anim.SetBool("DownLeft", true);
        }
        else if (movement.x > 0 && movement.y < 0)
        {
            anim.SetBool("DownRight", true);
        }
        else if (movement.x == 0 && movement.y == 0)
        {
            anim.SetBool("Idle", true);
        }
        cannotMove = CheckCollisions(box, movement, 0.05f);
    }

    private void FixedUpdate()
    {
        if (cannotMove)
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
