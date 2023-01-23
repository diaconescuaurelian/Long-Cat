using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public string bodyType;
    public string oldDir;
    public string newDir;

    void Start()
    {

    }
    void Update()
    {
        //on_edge = false;
        //MoveBody();
    }

    public void setNewDir(string dir)
    {
        newDir = dir;
    }
    public void setOldDir(string dir)
    {
        oldDir = dir;
    }
    public string getNewDir()
    {
        return newDir;
    }
    public string getOldDir()
    {
        return oldDir;
    }

    public void SetBodyType(string type)
    {
        bodyType = type;
    }

    public bool checkNewDir(string dir)
    {
        if (newDir == dir)
        {
            return true;
        }
        else return false;
    }
    public bool checkOldDir(string dir)
    {
        if (oldDir == dir)
        {
            return true;
        }
        else return false;
    }

    public bool checkBodyType(string type)
    {
        if (bodyType == type)
        {
            return true;
        }
        else return false;
    }

    //This function returns true if the old dir is the same as the new dir
    public bool checkIfDirIsChanged()
    {
        if (newDir != oldDir)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    

    /*
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

    */
}
