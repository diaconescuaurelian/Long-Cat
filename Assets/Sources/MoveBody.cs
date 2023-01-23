using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBody : Body
{
    private float timer = 0f;
    private static float moveTime = 0.9f;
    private static float quickMoveTime = 0.15f;
    public List<GameObject> cat = new List<GameObject>();
    private List<Body> bodyComponents = new List<Body>();
    // Start is called before the first frame update
    void Awake()
    {
         foreach (GameObject body in cat)
        {
            Body bodyPart = body.GetComponent<Body>();
            bodyComponents.Add(bodyPart);
        }

        for (int i = 0; i < cat.Count; i++)
        {
            if (i == 0)
            {
                bodyComponents[i].SetBodyType("head");
            }
            else
            {
                bodyComponents[i].SetBodyType("body");
            }
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bodyComponents.Count; i++)
        {
            if (bodyComponents[i].checkBodyType("head"))
            {
                Debug.Log(bodyComponents[i].bodyType + " " + i); 
                MoveHead();
            }
        }
    }
    void MoveHead()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer > quickMoveTime)
        {
            transform.position += transform.TransformDirection (Vector3.up);
            /*
            if (change_face && newDir == "right")
            { 
                transform.position += transform.TransformDirection (Vector3.right);
            }
            else if (change_face && newDir == "left")
            { 
                transform.position += transform.TransformDirection (Vector3.right);
            }
            else if (change_face && newDir == "up")
            { 
                transform.position += transform.TransformDirection (Vector3.right);
            }
            else if (change_face && newDir == "down")
            { 
                transform.position += transform.TransformDirection (Vector3.right);
            }
            //if it doesn't turn to another face of the cube
            else 
            {
                transform.position += transform.TransformDirection (Vector3.up);
            }
            */
            
            timer = 0;
        }
        else if (timer > moveTime)
        {
            transform.position += transform.TransformDirection (Vector3.up);
            /*
            if (change_face && newDir == "right")
            { 
                transform.position += transform.TransformDirection (Vector3.right);
            }
            else if (change_face && newDir == "left")
            { 
                transform.position += transform.TransformDirection (Vector3.right);
            }
            else if (change_face && newDir == "up")
            { 
                transform.position += transform.TransformDirection (Vector3.right);
            }
            else if (change_face && newDir == "down")
            { 
                transform.position += transform.TransformDirection (Vector3.right);
            }
            else
            {
                transform.position += transform.TransformDirection (Vector3.up);
            }
            //if it doesn't turn to another face of the cube
            
            */
            timer = 0;
        }
    }
    /*
    void ChangeDirection()
    {
        //Debug.Log("old direction: " + cat[1].GetComponent<Body>().old_direction);
        //Debug.Log("new direction: " + cat[1].GetComponent<Body>().new_direction);
        
        //for every bodypart of the cat starting from the one after the head
        for (int i = 1; i < cat.Count; i++)
        {
            cat[i].transform.position = cat[i-1].transform.position + cat[i - 1].transform.up * distance;
            //if the previous part is the head
            if (i - 1 == 0)
            {   
                //if the direction of the head is right
                if (cat[i-1].GetComponent<Move>().right == true)
                {
                    cat[i].GetComponent<Body>().old_direction = cat[i].GetComponent<Body>().new_direction;
                    cat[i].GetComponent<Body>().new_direction = "right";
                    if (cat[i].GetComponent<Body>().old_direction != cat[i].GetComponent<Body>().new_direction)
                    {
                        cat[i].GetComponent<Body>().rotate_count ++;
                    }
                    if (cat[i].GetComponent<Body>().rotate_count > 0)
                    {
                        if (cat[i].GetComponent<Body>().new_direction == "right" && cat[i].GetComponent<Body>().old_direction == "up")
                        {
                            cat[i].transform.Rotate(-90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                        else if (cat[i].GetComponent<Body>().new_direction == "right" && cat[i].GetComponent<Body>().old_direction == "down")
                        {
                            cat[i].transform.Rotate(90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                    }
                }
                
                //if the direction of the head is left
                else if (cat[i-1].GetComponent<Move>().left == true)
                {
                    cat[i].GetComponent<Body>().old_direction = cat[i].GetComponent<Body>().new_direction;
                    cat[i].GetComponent<Body>().new_direction = "left";
                    if (cat[i].GetComponent<Body>().old_direction != cat[i].GetComponent<Body>().new_direction)
                    {
                        cat[i].GetComponent<Body>().rotate_count ++;
                    }
                    if (cat[i].GetComponent<Body>().rotate_count > 0)
                    {
                        if (cat[i].GetComponent<Body>().new_direction == "left" && cat[i].GetComponent<Body>().old_direction == "up")
                        {
                            cat[i].transform.Rotate(90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                        else if (cat[i].GetComponent<Body>().new_direction == "left" && cat[i].GetComponent<Body>().old_direction == "down")
                        {
                            cat[i].transform.Rotate(-90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                    }
                }

                //if the direction of the head is up
                else if (cat[i-1].GetComponent<Move>().up == true)
                {
                    cat[i].GetComponent<Body>().old_direction = cat[i].GetComponent<Body>().new_direction;
                    cat[i].GetComponent<Body>().new_direction = "up";
                    if (cat[i].GetComponent<Body>().old_direction != cat[i].GetComponent<Body>().new_direction)
                    {
                        cat[i].GetComponent<Body>().rotate_count ++;
                    }
                    if (cat[i].GetComponent<Body>().rotate_count > 0)
                    {
                        if (cat[i].GetComponent<Body>().new_direction == "up" && cat[i].GetComponent<Body>().old_direction == "right")
                        {
                            cat[i].transform.Rotate(90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                        else if (cat[i].GetComponent<Body>().new_direction == "up" && cat[i].GetComponent<Body>().old_direction == "left")
                        {
                            cat[i].transform.Rotate(-90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                    }
                }

                //if the direction of the head is down
                else if (cat[i-1].GetComponent<Move>().down == true)
                {
                    cat[i].GetComponent<Body>().old_direction = cat[i].GetComponent<Body>().new_direction;
                    cat[i].GetComponent<Body>().new_direction = "down";
                    if (cat[i].GetComponent<Body>().old_direction != cat[i].GetComponent<Body>().new_direction)
                    {
                        cat[i].GetComponent<Body>().rotate_count ++;
                    }
                    if (cat[i].GetComponent<Body>().rotate_count > 0)
                    {
                        if (cat[i].GetComponent<Body>().new_direction == "down" && cat[i].GetComponent<Body>().old_direction == "right")
                        {
                            cat[i].transform.Rotate(270, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                        else if (cat[i].GetComponent<Body>().new_direction == "down" && cat[i].GetComponent<Body>().old_direction == "left")
                        {
                            cat[i].transform.Rotate(-270, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                    }
                }
                
                
            }

            //if the previous element is not the head
            else if (i - 1 > 0)
            {
                
                
                //set the old and new direction if it just started 
                if (cat[i].GetComponent<Body>().old_direction == "just started")
                {
                    cat[i].GetComponent<Body>().old_direction = cat[i - 1].GetComponent<Body>().old_direction;
                    cat[i].GetComponent<Body>().new_direction = cat[i - 1].GetComponent<Body>().old_direction;
                    //cat[i].transform.position = cat[i-1].transform.position + cat[i - 1].transform.up * distance;
                    if (cat[i].GetComponent<Body>().old_direction != cat[i].GetComponent<Body>().new_direction)
                    {
                        cat[i].GetComponent<Body>().rotate_count ++;
                    }
                    if (cat[i].GetComponent<Body>().rotate_count > 0)
                    {
                        if (cat[i].GetComponent<Body>().new_direction == "right" && cat[i].GetComponent<Body>().old_direction == "up")
                        {
                            cat[i].transform.Rotate(-90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                    }
                }
                //set the old and new direction after it already moved
                else
                {
                    cat[i].GetComponent<Body>().old_direction = cat[i].GetComponent<Body>().new_direction;
                    cat[i].GetComponent<Body>().new_direction = cat[i - 1].GetComponent<Body>().old_direction;
                    //cat[i].transform.position = cat[i-1].transform.position + cat[i - 1].transform.up * distance;
                    if (cat[i].GetComponent<Body>().old_direction != cat[i].GetComponent<Body>().new_direction)
                    {
                        cat[i].GetComponent<Body>().rotate_count ++;
                    }
                    if (cat[i].GetComponent<Body>().rotate_count > 0)
                    {
                        if (cat[i].GetComponent<Body>().new_direction == "right" && cat[i].GetComponent<Body>().old_direction == "up")
                        {
                            cat[i].transform.Rotate(-90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                        else if (cat[i].GetComponent<Body>().new_direction == "right" && cat[i].GetComponent<Body>().old_direction == "down")
                        {
                            cat[i].transform.Rotate(90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                        else if (cat[i].GetComponent<Body>().new_direction == "left" && cat[i].GetComponent<Body>().old_direction == "up")
                        {
                            cat[i].transform.Rotate(90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                        else if (cat[i].GetComponent<Body>().new_direction == "left" && cat[i].GetComponent<Body>().old_direction == "down")
                        {
                            cat[i].transform.Rotate(-90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                        else if (cat[i].GetComponent<Body>().new_direction == "up" && cat[i].GetComponent<Body>().old_direction == "right")
                        {
                            cat[i].transform.Rotate(90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                        else if (cat[i].GetComponent<Body>().new_direction == "up" && cat[i].GetComponent<Body>().old_direction == "left")
                        {
                            cat[i].transform.Rotate(-90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                        else if (cat[i].GetComponent<Body>().new_direction == "down" && cat[i].GetComponent<Body>().old_direction == "right")
                        {
                            cat[i].transform.Rotate(-90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                        else if (cat[i].GetComponent<Body>().new_direction == "down" && cat[i].GetComponent<Body>().old_direction == "left")
                        {
                            cat[i].transform.Rotate(90, 0, 0, Space.Self);
                            cat[i].GetComponent<Body>().rotate_count --;
                        }
                    }
                }
            }
        }
    }
    */
}
