using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    private bool isLeft;
    private bool isRight;
    private bool isUp;
    private bool isDown;
    private bool isUpLeft;
    private bool isUpRight;
    private bool isDownLeft;
    private bool isDownRight;
    // Start is called before the first frame update
    void Start()
    {
        if(transform.parent != null && transform.parent.tag == "Player1")
        {
            isLeft = false;
            isRight = true;
        }
        else if (transform.parent != null && transform.parent.tag == "Player2")
        {
            isLeft = true;
            isRight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseMenu.GameIsPaused == false)
        {


            if (transform.parent != null && transform.parent.tag == "Player1")
            {
                if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.W))
                {
                    rotateUp();
                }
                else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
                {
                    rotateDown();
                }
                else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                {
                    rotateLeft();
                }
                else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                {
                    rotateRight();
                }
                else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
                {
                    rotateUpLeft();
                }
                else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
                {
                    rotateUpRight();
                }
                else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
                {
                    rotateDownRight();
                }
                else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
                {
                    rotateDownLeft();
                }
                else if (Input.GetKey(KeyCode.W))
                {
                    rotateUp();
                }
                else if (Input.GetKey(KeyCode.S))
                {
                    rotateDown();
                }
                else if (Input.GetKey(KeyCode.D))
                {
                    rotateRight();
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    rotateLeft();
                }
            }
            else if (transform.parent != null && transform.parent.tag == "Player2")
            {
                if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow))
                {
                    rotateUp();
                }
                else if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow))
                {
                    rotateDown();
                }
                else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
                {
                    rotateLeft();
                }
                else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
                {
                    rotateRight();
                }
                else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftArrow))
                {
                    rotateUpLeft();
                }
                else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow))
                {
                    rotateUpRight();
                }
                else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.RightArrow))
                {
                    rotateDownRight();
                }
                else if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow))
                {
                    rotateDownLeft();
                }
                else if (Input.GetKey(KeyCode.UpArrow))
                {
                    rotateUp();
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    rotateDown();
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    rotateRight();
                }
                else if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rotateLeft();
                }
            }
        }
    }
    public void rotateLeft()
    {
        transform.localEulerAngles = new Vector3(0f, 180f, 0f);
        transform.localPosition = new Vector3(-0.7f, 0f, 0f);
        isRight = false;
        isLeft = true;
        isUp = false;
        isDown = false;
        isUpLeft = false;
        isUpRight = false;
        isDownLeft = false;
        isDownRight = false;

    }

    public void rotateRight()
    {
        transform.localEulerAngles = new Vector3(0f, 0f, 0f);
        transform.localPosition = new Vector3(0.7f, 0f, 0f);
        isLeft = false;
        isRight = true;
        isUp = false;
        isDown = false;
        isUpLeft = false;
        isUpRight = false;
        isDownLeft = false;
        isDownRight = false;
    }

    public void rotateUp()
    {
        transform.localEulerAngles = new Vector3(0f, 0f, 90f);
        transform.localPosition = new Vector3(0f, 0.7f, 0f);
        isLeft = false;
        isRight = false;
        isUp = true;
        isDown = false;
        isUpLeft = false;
        isUpRight = false;
        isDownLeft = false;
        isDownRight = false;
    }

    public void rotateDown()
    {
        transform.localEulerAngles = new Vector3(0f, 0f, -90f);
        transform.localPosition = new Vector3(0f, -0.7f, 0f);
        isLeft = false;
        isRight = false;
        isUp = false;
        isDown = true;
        isUpLeft = false;
        isUpRight = false;
        isDownLeft = false;
        isDownRight = false;
    }

    public void rotateUpLeft()
    {
        transform.localEulerAngles = new Vector3(0f, 180f, 45f);
        transform.localPosition = new Vector3(-0.7f, 0.6f, 0f);
        isLeft = false;
        isRight = false;
        isUp = false;
        isDown = false;
        isUpLeft = true;
        isUpRight = false;
        isDownLeft = false;
        isDownRight = false;
    }

    public void rotateUpRight()
    {
        transform.localEulerAngles = new Vector3(0f, 0f, 45f);
        transform.localPosition = new Vector3(0.7f, 0.6f, 0f);
        isLeft = false;
        isRight = false;
        isUp = false;
        isDown = false;
        isUpLeft = false;
        isUpRight = true;
        isDownLeft = false;
        isDownRight = false;
    }

    public void rotateDownLeft()
    {
        transform.localEulerAngles = new Vector3(0f, 180f, -45f);
        transform.localPosition = new Vector3(-0.7f, -0.6f, 0f);
        isLeft = false;
        isRight = false;
        isUp = false;
        isDown = false;
        isUpLeft = false;
        isUpRight = false;
        isDownLeft = true;
        isDownRight = false;
    }

    public void rotateDownRight()
    {
        transform.localEulerAngles = new Vector3(0f, 0f, -45f);
        transform.localPosition = new Vector3(0.7f, -0.6f, 0f);
        isLeft = false;
        isRight = false;
        isUp = false;
        isDown = false;
        isUpLeft = false;
        isUpRight = false;
        isDownLeft = false;
        isDownRight = true;
    }
}
