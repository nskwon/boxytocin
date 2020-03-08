using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector2 movement;
    private Rigidbody2D rb;
    private BoxCollider2D box;
    private bool cannotMove;
    Animator anim;
    private bool left;
    private bool right;
    private bool up;
    private bool down;
    private bool upLeft;
    private bool upRight;
    private bool downLeft;
    private bool downRight;
    HealthSystem player1Health = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        player1Health = FindObjectOfType<HealthSystem>();
        if(player1Health != null){
            player1Health.addHealth(100);
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal1");
        movement.y = Input.GetAxisRaw("Vertical1");
        
        cannotMove = CheckCollisions(box, movement, 0.05f);

        //Movement Animations
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Up", true);
            anim.SetBool("UpLeft", false);
            anim.SetBool("Down", false);
            anim.SetBool("DownLeft", false);
            anim.SetBool("UpRight", false);
            anim.SetBool("Left", false);
            anim.SetBool("DownRight", false);
            anim.SetBool("Right", false);
            up = true;
            left = false;
            right = false;
            up = false;
            down = false;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Up", false);
            anim.SetBool("UpLeft", false);
            anim.SetBool("Down", true);
            anim.SetBool("DownLeft", false);
            anim.SetBool("UpRight", false);
            anim.SetBool("Left", false);
            anim.SetBool("DownRight", false);
            anim.SetBool("Right", false);
            left = false;
            right = false;
            up = false;
            down = true;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Up", false);
            anim.SetBool("UpLeft", false);
            anim.SetBool("Down", false);
            anim.SetBool("DownLeft", false);
            anim.SetBool("UpRight", false);
            anim.SetBool("Left", true);
            anim.SetBool("DownRight", false);
            anim.SetBool("Right", false);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Up", false);
            anim.SetBool("UpLeft", false);
            anim.SetBool("Down", false);
            anim.SetBool("DownLeft", false);
            anim.SetBool("UpRight", false);
            anim.SetBool("Left", false);
            anim.SetBool("DownRight", false);
            anim.SetBool("Right", true);
        }
        else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Up", false);
            anim.SetBool("UpLeft", true);
            anim.SetBool("Down", false);
            anim.SetBool("DownLeft", false);
            anim.SetBool("UpRight", false);
            anim.SetBool("Left", false);
            anim.SetBool("DownRight", false);
            anim.SetBool("Right", false);
        }
        else if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Up", false);
            anim.SetBool("UpLeft", false);
            anim.SetBool("Down", false);
            anim.SetBool("DownLeft", false);
            anim.SetBool("UpRight", true);
            anim.SetBool("Left", false);
            anim.SetBool("DownRight", false);
            anim.SetBool("Right", false);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Up", false);
            anim.SetBool("UpLeft", false);
            anim.SetBool("Down", false);
            anim.SetBool("DownLeft", false);
            anim.SetBool("UpRight", false);
            anim.SetBool("Left", false);
            anim.SetBool("DownRight", true);
            anim.SetBool("Right", false);
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Up", false);
            anim.SetBool("UpLeft", false);
            anim.SetBool("Down", false);
            anim.SetBool("DownLeft", true);
            anim.SetBool("UpRight", false);
            anim.SetBool("Left", false);
            anim.SetBool("DownRight", false);
            anim.SetBool("Right", false);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Up", true);
            anim.SetBool("UpLeft", false);
            anim.SetBool("Down", false);
            anim.SetBool("DownLeft", false);
            anim.SetBool("UpRight", false);
            anim.SetBool("Left", false);
            anim.SetBool("DownRight", false);
            anim.SetBool("Right", false);
            left = false;
            right = false;
            up = true;
            down = false;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Up", false);
            anim.SetBool("UpLeft", false);
            anim.SetBool("Down", true);
            anim.SetBool("DownLeft", false);
            anim.SetBool("UpRight", false);
            anim.SetBool("Left", false);
            anim.SetBool("DownRight", false);
            anim.SetBool("Right", false);
            left = false;
            right = false;
            up = false;
            down = true;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Up", false);
            anim.SetBool("UpLeft", false);
            anim.SetBool("Down", false);
            anim.SetBool("DownLeft", false);
            anim.SetBool("UpRight", false);
            anim.SetBool("Left", false);
            anim.SetBool("DownRight", false);
            anim.SetBool("Right", true);
            left = false;
            right = true;
            up = false;
            down = false;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Up", false);
            anim.SetBool("UpLeft", false);
            anim.SetBool("Down", false);
            anim.SetBool("DownLeft", false);
            anim.SetBool("UpRight", false);
            anim.SetBool("Left", true);
            anim.SetBool("DownRight", false);
            anim.SetBool("Right", false);
            left = true;
            right = false;
            up = false;
            down = false;
            upLeft = false;
            upRight = false;
            downLeft = false;
            downRight = false;
        }


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
    
    private void flipHorizontal(bool direction){
        
    }

}
