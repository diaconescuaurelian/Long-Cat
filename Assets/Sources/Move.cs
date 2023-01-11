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
    public bool can_turn;
    public Queue<string> turnQ = new Queue<string>();
    
    void Awake()
    {
        move_cam = GameObject.FindGameObjectWithTag("MainCamera");
        can_turn = true;
    }
    void Update()
    {
        if (move_cam.GetComponent<RotateCamera>().finished == true)
        {
            if (can_turn)
            {
                Turn();
            }
            //MoveHead();
        }
        MoveHead();
        //daca move head e in if se face un delay
        //cum fac sa astepte si body parts
    }
    //When facing a direction and colliding with an edge, turn 90 degrees and move forward 1 unit
    void OnTriggerEnter(Collider collision)
    {
        //fara transform.position nu mai e bugul de pe margine
        if (collision.gameObject.tag == "Edge" && right == true)
        {
            transform.Rotate(0, 0, -90, Space.Self);
            //transform.position += transform.TransformDirection (Vector3.up);
            turnQ.Enqueue("right");
            can_turn = false;
        }
        
        else if (collision.gameObject.tag == "Edge" && left == true)
        {
            transform.Rotate(0, 0, -90, Space.Self);
            //transform.position += transform.TransformDirection (Vector3.up);
            turnQ.Enqueue("left");
            can_turn = false;
        }

        else if (collision.gameObject.tag == "Edge" && up == true)
        {
            transform.Rotate(0, 0, -90, Space.Self);
            //transform.position += transform.TransformDirection (Vector3.up);
            turnQ.Enqueue("up");
            can_turn = false;
        }

        else if (collision.gameObject.tag == "Edge" && down == true)
        {
            transform.Rotate(0, 0, -90, Space.Self);
            //transform.position += transform.TransformDirection (Vector3.up);
            turnQ.Enqueue("down");
            can_turn = false;
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Edge")
        {
            can_turn = true;
        }

        if (collision.gameObject.tag == "Food")
        {
            can_turn = true;
        }
    }
    //Function that moves the head of the cat
    void MoveHead()
    {
        timer += 1* Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer > quickMoveTime)
        {
            transform.position += transform.TransformDirection (Vector3.up);
            timer = 0;
        }
        else if (timer > moveTime)
        {
            transform.position += transform.TransformDirection (Vector3.up);
            timer = 0;
        }
    }
    //Function that turns the head of the cat
    void Turn()
    {   //trebuie sa mai fac o conditie si cu ceva timer la turn
        //sau poate ceva cu old dir si new dir
        //Turn Right if facing up
        if (Input.GetKeyDown(KeyCode.RightArrow) && up == true  && right == false && left == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) ==false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            right = true;
            up = false;
        }
        //Turn Right if facing down
        if (Input.GetKeyDown(KeyCode.RightArrow) &&  down == true && right == false && left == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) ==false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            right = true;
            down = false;
        }
        //Turn Left if facing up
        if (Input.GetKeyDown(KeyCode.LeftArrow) && up == true  && left == false && right == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) ==false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            left = true;
            up = false;
        }
        //Turn Left if facing down
        if (Input.GetKeyDown(KeyCode.LeftArrow) && down == true && left == false && right == false && Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) ==false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            left = true;
            down = false;
        }
        //Turn Up if facing right
        if (Input.GetKeyDown(KeyCode.UpArrow) &&  right == true && up == false && down == false && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) ==false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            up = true;
            right = false;
        }
        //Turn Up if facing left
        if (Input.GetKeyDown(KeyCode.UpArrow) && left == true  && up == false && down == false && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) ==false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            up = true;
            left = false;
        }
        //Turn Down if facing 
        if (Input.GetKeyDown(KeyCode.DownArrow) &&  right == true && up == false && down == false && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) ==false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            down = true;
            right = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && left == true  && up == false && down == false && Input.GetKey(KeyCode.LeftArrow) == false && Input.GetKey(KeyCode.RightArrow) ==false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
            down = true;
            left = false;
        }
    }
}
