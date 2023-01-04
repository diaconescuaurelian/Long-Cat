using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    float timer = 0f;
    public Vector3 frontPos;
    public static float moveTime = 0.9f;
    public static float quickMoveTime = 0.05f;
    bool right = false;
    bool left = false;
    bool up = true;
    bool down =false;

    void Update()
    {
        timer += 1* Time.deltaTime;

        MoveHead();
        Turn();
        
    }
    //Function that moves the head of the cat
    void MoveHead()
    {
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
    {   //Turn Right if facing up
        if (Input.GetKeyDown(KeyCode.RightArrow) && up == true  && right == false && left == false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            right = true;
            up = false;
        }
        //Turn Right if facing down
        if (Input.GetKeyDown(KeyCode.RightArrow) &&  down == true && right == false && left == false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            right = true;
            down = false;
        }
        //Turn Left if facing up
        if (Input.GetKeyDown(KeyCode.LeftArrow) && up == true  && left == false && right == false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            left = true;
            up = false;
        }
        //Turn Left if facing down
        if (Input.GetKeyDown(KeyCode.LeftArrow) && down == true && left == false && right == false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            left = true;
            down = false;
        }
        //Turn Up if facing right
        if (Input.GetKeyDown(KeyCode.UpArrow) &&  right == true && up == false && down == false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            up = true;
            right = false;
        }
        //Turn Up if facing left
        if (Input.GetKeyDown(KeyCode.UpArrow) && left == true  && up == false && down == false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            up = true;
            left = false;
        }
        //Turn Down if facing 
        if (Input.GetKeyDown(KeyCode.DownArrow) &&  right == true && up == false && down == false)
        {
            transform.Rotate(-90, 0, 0, Space.Self);
            down = true;
            right = false;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && left == true  && up == false && down == false)
        {
            transform.Rotate(90, 0, 0, Space.Self);
            down = true;
            left = false;
        }
    }
}
