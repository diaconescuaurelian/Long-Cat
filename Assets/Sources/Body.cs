using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public static float moveTime = 0.9f;
    public static float quickMoveTime = 0.07f;
    public string old_direction = "just started";
    public string new_direction;

    public int rotate_count;

    void Update()
    {
        //MoveBody();
    }
    /*
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Edge" && new_direction == "right")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
        }
        
        else if (collision.gameObject.tag == "Edge" && new_direction == "left")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
        }

        if (collision.gameObject.tag == "Edge" && new_direction == "up")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
        }

        else if (collision.gameObject.tag == "Edge" && new_direction == "down")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            transform.position += transform.TransformDirection (Vector3.up);
        }
    }
    */
}
