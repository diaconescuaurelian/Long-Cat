using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    GameObject move_cam;
    public float timer = 0f;
    public static float moveTime = 0.9f;
    public static float quickMoveTime = 0.15f;
    public bool right = false;
    public bool left = false;
    public bool up = true;
    public bool down = false;
    public bool can_move;
    public Queue<string> turnQ = new Queue<string>();
    
    void Awake()
    {
        move_cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {
        if (move_cam.GetComponent<RotateCamera>().finished == true)
        {
            can_move = false;
            Turn();
            MoveHead();
        }
    }
    //When facing a direction and colliding with an edge, turn 90 degrees and move forward 1 unit
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Edge" && right == true)
        {
            transform.Rotate(0, 0, -90, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            can_move = true;
            turnQ.Enqueue("right");
        }
        
        else if (collision.gameObject.tag == "Edge" && left == true)
        {
            transform.Rotate(0, 0, -90, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            can_move = true;
            turnQ.Enqueue("left");
        }

        if (collision.gameObject.tag == "Edge" && up == true)
        {
            transform.Rotate(0, 0, -90, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            can_move = true;
            turnQ.Enqueue("up");
        }

        else if (collision.gameObject.tag == "Edge" && down == true)
        {
            transform.Rotate(0, 0, -90, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            can_move = true;
            turnQ.Enqueue("down");
        }
    }
    //Function that moves the head of the cat
    void MoveHead()
    {
        timer += 1* Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer > quickMoveTime)
        {
            transform.position += transform.TransformDirection (Vector3.up);
            can_move = true;
            timer = 0;
        }
        else if (timer > moveTime)
        {
            transform.position += transform.TransformDirection (Vector3.up);
            can_move = true;
            timer = 0;
        }
    }
    //Function that turns the head of the cat
    void Turn()
    {   //Turn Right if facing up
        if (Input.GetKey(KeyCode.RightArrow) && up == true  && right == false && left == false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            right = true;
            up = false;
        }
        //Turn Right if facing down
        if (Input.GetKey(KeyCode.RightArrow) &&  down == true && right == false && left == false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            right = true;
            down = false;
        }
        //Turn Left if facing up
        if (Input.GetKey(KeyCode.LeftArrow) && up == true  && left == false && right == false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            left = true;
            up = false;
        }
        //Turn Left if facing down
        if (Input.GetKey(KeyCode.LeftArrow) && down == true && left == false && right == false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            left = true;
            down = false;
        }
        //Turn Up if facing right
        if (Input.GetKey(KeyCode.UpArrow) &&  right == true && up == false && down == false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            up = true;
            right = false;
        }
        //Turn Up if facing left
        if (Input.GetKey(KeyCode.UpArrow) && left == true  && up == false && down == false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            up = true;
            left = false;
        }
        //Turn Down if facing 
        if (Input.GetKey(KeyCode.DownArrow) &&  right == true && up == false && down == false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            down = true;
            right = false;
        }

        if (Input.GetKey(KeyCode.DownArrow) && left == true  && up == false && down == false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            down = true;
            left = false;
        }
    }
}
