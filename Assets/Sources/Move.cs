using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Body
{
    public float timer = 0f;
    private static float moveTime = 0.9f;
    private static float quickMoveTime = 0.15f;
    private int distance = -1;
    private GameObject catObject;
    private MoveCat moveCatScript;
    private bool moved;
    private int counterChangeFace = 0;
    private bool turnBody;
    private bool positionRight;
    private Vector3 previousBodyPosition;
    Transform curveRight;
    Transform curveLeft;
    Transform curveFace;
    Transform standard;
    Transform tail;


    void Awake()
    {
        catObject = GameObject.FindGameObjectWithTag("LongCat");
        moveCatScript = catObject.GetComponent<MoveCat>();
    }

    // Method that will be used to move the head in its up direction with 1 unit at every 0.9 or 0.15 if space key is pressed.
    public void MoveHead(GameObject head, bool changeFace, string newDir, bool turned, Move next)//capul se muta bine pe alte fete, mai trebuie modificat pentru body elements
    {
        timer += Time.deltaTime;
        //if the head turned and the head has to move in less than 0.05 seconds, reset the timer
        //this way it will have enough time for the body parts to rotate corectly when turning to another face
        if (Input.GetKey(KeyCode.Space) && turned)
        {
            if (timer > 0.10f)
            {
                timer = 0.10f;
            }
        }
        if (Input.GetKey(KeyCode.Space) && timer > quickMoveTime)
        {
            //head.transform.position += transform.TransformDirection (Vector3.up);
            //Debug.Log(changeFace);
            if (changeFace)
            { 
                head.transform.position += transform.TransformDirection (Vector3.right);
                transform.Rotate(0, 0, -90, Space.Self);
                //increments the counter for the body behind the head when the head moves on another face of the cube
                next.IncrementCounterChangeFace();
                moved = true;
            }
            //if it doesn't turn to another face of the cube
            else 
            {
                head.transform.position += transform.TransformDirection (Vector3.up);
                moved = true;

            }
            timer = 0;
            moveCatScript.SetMovedHeadList();
        }
        // if the space key is not pressed the head moves at a slower speed
        else if (timer > moveTime)
        {
            if (changeFace)
            { 
                head.transform.position += transform.TransformDirection (Vector3.right);
                transform.Rotate(0, 0, -90, Space.Self);
                //increments the counter for the body behind the head when the head moves on another face of the cube
                next.IncrementCounterChangeFace();
            }
            else
            {
                head.transform.position += transform.TransformDirection (Vector3.up);
            }
            timer = 0;
            moveCatScript.SetMovedHeadList();
        }
    }

    //This method will be used to move each body part 1 unit behind a previous body part
    //The firt body part after head will allways be moved at 1 unit behind the head
    public void MoveBody(GameObject body, GameObject front,  ChangeDirection previous, Move next, int index)
    {
        if (front.transform.position != previousBodyPosition)
        {
            body.transform.position = front.transform.position + front.transform.up * distance;
            if (index < moveCatScript.cat.Count - 1)
            {
                curveRight = transform.Find("CatCurveRight");
                curveRight.gameObject.SetActive(false);
                curveLeft = transform.Find("CatCurveLeft");
                curveLeft.gameObject.SetActive(false);
                curveFace = transform.Find("CatCurveFace");
                curveFace.gameObject.SetActive(false);
                standard = transform.Find("BodyPartStandard");
                standard.gameObject.SetActive(true);
                tail = transform.Find("CatTail");
                tail.gameObject.SetActive(false);
            }
            
            //if the current body is the last one rotate it if the counter is 1, that is at the same time with the one in fron of him
            if (index == moveCatScript.cat.Count - 1 && counterChangeFace == 1)
            {
                transform.Rotate(0, 0, -90, Space.Self);
                counterChangeFace = 0;
            }
            //if the current body is not the last one, increment the counter if it's one, and rotate it if it's 2
            else
            {
                if (counterChangeFace ==1)
                {
                    counterChangeFace++;
                    if (index < moveCatScript.cat.Count - 1)
                    {
                        curveRight = transform.Find("CatCurveRight");
                        curveRight.gameObject.SetActive(false);
                        curveLeft = transform.Find("CatCurveLeft");
                        curveLeft.gameObject.SetActive(false);
                        curveFace = transform.Find("CatCurveFace");
                        curveFace.gameObject.SetActive(true);
                        standard = transform.Find("BodyPartStandard");
                        standard.gameObject.SetActive(false);
                        tail = transform.Find("CatTail");
                        tail.gameObject.SetActive(false);
                    }
                }
                else if (counterChangeFace == 2)
                {
                    
                    transform.Rotate(0, 0, -90, Space.Self);
                    //muta
                    //incrementeaza contorul body-ului din spatele lui
                    if (index < moveCatScript.cat.Count - 1)
                    {
                        next.IncrementCounterChangeFace();
                    }
                    //reseteaza propriul contor la 0
                    counterChangeFace = 0;
                }
            }
            
            previousBodyPosition = front.transform.position;
        }
    }

    public bool getMoved()
    {
        return moved;
    } 
    public void setMoved(bool val)
    {
        moved = val;
    }
    public float getTimer()
    {
        return timer;
    }
    public void IncrementCounterChangeFace()
    {
        counterChangeFace++;
    }
    public void setPreviousBodyPosition(Vector3 prevPosition)
    {
        previousBodyPosition = prevPosition;
    }
    
}
