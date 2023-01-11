using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public static float moveTime = 0.9f;
    public static float quickMoveTime = 0.07f;
    public string old_direction = "just started";
    public string new_direction;
    //public Queue<string> on_edgeQ = new Queue<string>();
    public int rotate_count;
    public bool on_edge;

    void Start()
    {
        on_edge = false;
    }
    void Update()
    {
        //on_edge = false;
        //MoveBody();
    }
    
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Edge" && new_direction == "right")
        {
            Debug.Log("Coliziune  " + new_direction);
            transform.Rotate(0, 0, -90, Space.Self);
            //transform.position += transform.TransformDirection (Vector3.up);
            on_edge = true;
            //on_edge.Enqueue("right");
            //transform.position += transform.TransformDirection (Vector3.up);
        }
        
        else if (collision.gameObject.tag == "Edge" && new_direction == "left")
        {
            Debug.Log("Coliziune  " + new_direction);
            transform.Rotate(0, 0, -90, Space.Self);
            //transform.position += transform.TransformDirection (Vector3.up);
            on_edge = true;
            //on_edge.Enqueue("left");
            //transform.position += transform.TransformDirection (Vector3.up);
        }

        if (collision.gameObject.tag == "Edge" && new_direction == "up")
        {
            Debug.Log("Coliziune  " + new_direction);
            transform.Rotate(0, 0, -90, Space.Self);
            //transform.position += transform.TransformDirection (Vector3.up);
            on_edge = true;
            //on_edge.Enqueue("up");
            //transform.position += transform.TransformDirection (Vector3.up);
        }

        else if (collision.gameObject.tag == "Edge" && new_direction == "down")
        {
            Debug.Log("Coliziune  " + new_direction);
            transform.Rotate(0, 0, -90, Space.Self);
            //transform.position += transform.TransformDirection (Vector3.up);
            on_edge = true;
            //on_edge.Enqueue("down");
            //transform.position += transform.TransformDirection (Vector3.up);
        }
    }

    void OnTriggerExit(Collider collision)
    {
         if (collision.gameObject.tag == "Edge")
         {
            on_edge = false;
         }
    }

    
}
