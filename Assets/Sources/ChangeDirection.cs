using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeDirection : Body
{
    private GameObject catObject;
    private MoveCat moveCatScript;
    private bool changeFace;
    private bool changeFaceFront;
    public bool canTurn = true;
    private Queue<string> turnQ = new Queue<string>();
    private bool turned = false;
    private int rotateCount = 0;
    private int rotationType;
    private float turnAgainTimer = 0.0f;
    Transform curveRight;
    Transform curveLeft;
    Transform curveFace;
    Transform standard;
    Transform tail;
    //bool headCanTurn = true;
    void Awake()
    {
        oldDir = "just started";
        
        catObject = GameObject.FindGameObjectWithTag("LongCat");
        moveCatScript = catObject.GetComponent<MoveCat>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TurnAgain();
    }
    
    public void TurnHead(GameObject head, ChangeDirection headDirections, Move headMove) 
    {   //mai verifica la TurnHead cu delay daca se afla pe collider sa nu mai faca deloc rotirea
        if (Input.GetKeyDown(KeyCode.RightArrow) && checkNewDir("up") && !changeFace && turnAgainTimer > 0.01f)
        {
            rotationType = 1;
            //turn the head only if enough time has passed since the last time the head moved
            if (headMove.getTimer() < 0.05f)
            {
                StartCoroutine(DelayTurn(headMove.getTimer(), headDirections));
            }
            //rotate the head, move it 1 unit in its up direction, and set its direction
            //then set the list of bool to true so that move body can be called
            //set the timer that is used to check if no 2 consecutive head turns take place at an interval too short one after the other
            else
            {
                transform.Rotate(-90, 0, 0, Space.Self);
                transform.position += transform.TransformDirection (Vector3.up);
                headDirections.setNewDir("right");
                headDirections.setOldDir("up");
                moveCatScript.SetTurnedHeadList();
                turned = true;
                turnAgainTimer = 0.0f;
            }
            
        }
        //Turn right if facing down
        else if (Input.GetKeyDown(KeyCode.RightArrow) && checkNewDir("down") && !changeFace && turnAgainTimer > 0.03f)
        {
            rotationType = 2;
            if (headMove.getTimer() < 0.05f)
            {
                StartCoroutine(DelayTurn(headMove.getTimer(), headDirections));
            }
            else
            {
                head.transform.Rotate(90, 0, 0, Space.Self);
                head.transform.position += transform.TransformDirection (Vector3.up);
                headDirections.setNewDir("right");
                headDirections.setOldDir("down");
                moveCatScript.SetTurnedHeadList();
                turned = true;
                turnAgainTimer = 0.0f;
            }
            
        }
        //Turn left if facing up
        else if (Input.GetKeyDown(KeyCode.LeftArrow)  && checkNewDir("up") && !changeFace && turnAgainTimer > 0.03f)
        {
            rotationType = 3;
            if ( headMove.getTimer() < 0.05f)
            {
                StartCoroutine(DelayTurn(headMove.getTimer(), headDirections));
            }
            else
            {
                head.transform.Rotate(90, 0, 0, Space.Self);
                head.transform.position += transform.TransformDirection (Vector3.up);
                headDirections.setNewDir("left");
                headDirections.setOldDir("up");
                moveCatScript.SetTurnedHeadList();
                turned = true;
                turnAgainTimer = 0.0f;
            }
        }
        //Turn left if facing down
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && checkNewDir("down") && !changeFace && turnAgainTimer > 0.03f)
        {
            rotationType = 4;
            if ( headMove.getTimer() < 0.05f)
            {
                StartCoroutine(DelayTurn(headMove.getTimer(), headDirections));
            }
            else
            {
                head.transform.Rotate(-90, 0, 0, Space.Self);
                head.transform.position += transform.TransformDirection (Vector3.up);
                headDirections.setNewDir("left");
                headDirections.setOldDir("down");
                moveCatScript.SetTurnedHeadList();
                turned = true;
                turnAgainTimer = 0.0f;
            }
        }
        //Turn up if facing right
        else if (Input.GetKeyDown(KeyCode.UpArrow) &&  checkNewDir("right") && !changeFace && turnAgainTimer > 0.03f)
        {
            rotationType = 5;
            if (headMove.getTimer() < 0.05f)
            {
                StartCoroutine(DelayTurn(headMove.getTimer(), headDirections));
            }
            else
            {
                head.transform.Rotate(90, 0, 0, Space.Self);
                head.transform.position += transform.TransformDirection (Vector3.up);
                headDirections.setNewDir("up");
                headDirections.setOldDir("right");
                moveCatScript.SetTurnedHeadList();
                turned = true;
                turnAgainTimer = 0.0f;
            }
            
        }
        //Turn up if facing left
        else if (Input.GetKeyDown(KeyCode.UpArrow) && checkNewDir("left") && !changeFace && turnAgainTimer > 0.03f)
        {
            rotationType = 6;
            if (headMove.getTimer() < 0.05f)
            {
                StartCoroutine(DelayTurn(headMove.getTimer(), headDirections));
            }
            else
            {
                head.transform.Rotate(-90, 0, 0, Space.Self);
                head.transform.position += transform.TransformDirection (Vector3.up);
                headDirections.setNewDir("up");
                headDirections.setOldDir("left");
                moveCatScript.SetTurnedHeadList();
                turned = true;
                turnAgainTimer = 0.0f;
            }
            
        }
        //Turn down if facing right
        else if (Input.GetKeyDown(KeyCode.DownArrow) &&  checkNewDir("right") && !changeFace && turnAgainTimer > 0.03f)
        {
            rotationType = 7;
            if (headMove.getTimer() < 0.05f)
            {
                StartCoroutine(DelayTurn(headMove.getTimer(), headDirections));
            }
            else
            {
                head.transform.Rotate(-90, 0, 0, Space.Self);
                head.transform.position += transform.TransformDirection (Vector3.up);
                headDirections.setNewDir("down");
                headDirections.setOldDir("right");
                moveCatScript.SetTurnedHeadList();
                turned = true;
                turnAgainTimer = 0.0f;
            }
            
        }
        //Turn down if facing left
        else if (Input.GetKeyDown(KeyCode.DownArrow) && checkNewDir("left") && !changeFace && turnAgainTimer > 0.03f)
        {
            rotationType = 8;
            if (headMove.getTimer() < 0.05f)
            {
                StartCoroutine(DelayTurn(headMove.getTimer(), headDirections));
            }
            else
            {
                head.transform.Rotate(90, 0, 0, Space.Self);
                head.transform.position += transform.TransformDirection (Vector3.up);
                headDirections.setNewDir("down");
                headDirections.setOldDir("left");
                moveCatScript.SetTurnedHeadList();
                turned = true;
                turnAgainTimer = 0.0f;
            }
            
        }
    } 
    public void TurnBody(GameObject body, ChangeDirection nextBody, ChangeDirection front, int index)
    {
        moveCatScript.SetMovedHeadElement(index);
        moveCatScript.SetTurnedHeadElement(index);
        //Debug.Log(front.getNewDir() + " Turn Body");
        //for every bodypart of the cat starting from the one after the head
        //if the element in front of this one is the head, it takes the newDir of the head
        if (front.checkBodyType("head")) 
            {
                oldDir = newDir;
                newDir = front.getNewDir();
            }
        //if the element in front is just another body, take the oldDir of that body
        else 
        {
            oldDir = newDir;
            newDir = front.getOldDir(); 
        }
        
        //if newDir != oldDir we increment the counter
        if (checkIfDirIsChanged())
        {
            rotateCount ++;
        }
            //we only rotate when the counter is 1 if the oldDir==newDir, in the specific direction
            //otherwise we only rotate the body if the counter is > 1,
            if (rotateCount > 0) 
            {
                if (checkNewDir("right") && checkOldDir("up")) 
                {
                    if (index < moveCatScript.cat.Count - 1)
                    {
                        curveRight = transform.Find("CatCurveRight");
                        curveRight.gameObject.SetActive(true);
                        curveLeft = transform.Find("CatCurveLeft");
                        curveLeft.gameObject.SetActive(false);
                        curveFace = transform.Find("CatCurveFace");
                        curveFace.gameObject.SetActive(false);
                        standard = transform.Find("BodyPartStandard");
                        standard.gameObject.SetActive(false);
                        tail = transform.Find("CatTail");
                        tail.gameObject.SetActive(false);
                    }
                    
                    if(rotateCount > 1)
                    {
                        //if the newDir of the body behind this one is the same with our newDir, we rotate with 90 degrees in the opposite direction than normal
                        if (nextBody.checkNewDir("right"))
                        {
                            body.transform.Rotate(90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                        else
                        {
                            body.transform.Rotate(-90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                        
                    }
                }
                else if (rotateCount == 1 && checkNewDir("right") && checkOldDir("right") && nextBody.checkNewDir("up"))
                {
                    body.transform.Rotate(-90, 0, 0, Space.Self);
                    rotateCount--;
                }
                else if (checkNewDir("right") && checkOldDir("down"))
                {
                    if (index < moveCatScript.cat.Count - 1)
                    {
                        curveRight = transform.Find("CatCurveRight");
                        curveRight.gameObject.SetActive(false);
                        curveLeft = transform.Find("CatCurveLeft");
                        curveLeft.gameObject.SetActive(true);
                        curveFace = transform.Find("CatCurveFace");
                        curveFace.gameObject.SetActive(false);
                        standard = transform.Find("BodyPartStandard");
                        standard.gameObject.SetActive(false);
                        tail = transform.Find("CatTail");
                        tail.gameObject.SetActive(false);
                    }
                    
                    if(rotateCount > 1)
                    {
                        if (nextBody.checkNewDir("right"))
                        {
                            body.transform.Rotate(-90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                        else
                        {
                            body.transform.Rotate(90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                    }
                }
                else if (rotateCount == 1 && checkNewDir("right") && checkOldDir("right") && nextBody.checkNewDir("down"))
                {
                    body.transform.Rotate(90, 0, 0, Space.Self);
                    rotateCount--;
                }
                else if (checkNewDir("left") && checkOldDir("up"))
                {
                    if (index < moveCatScript.cat.Count - 1)
                    {
                        curveRight = transform.Find("CatCurveRight");
                        curveRight.gameObject.SetActive(false);
                        curveLeft = transform.Find("CatCurveLeft");
                        curveLeft.gameObject.SetActive(true);
                        curveFace = transform.Find("CatCurveFace");
                        curveFace.gameObject.SetActive(false);
                        standard = transform.Find("BodyPartStandard");
                        standard.gameObject.SetActive(false);
                        tail = transform.Find("CatTail");
                        tail.gameObject.SetActive(false);
                    }
                    
                    if(rotateCount > 1)
                    {
                        if (nextBody.checkNewDir("left"))
                        {
                            body.transform.Rotate(-90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                        else
                        {
                            body.transform.Rotate(90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                    }
                }
                else if (rotateCount == 1 && checkNewDir("left") && checkOldDir("left") && nextBody.checkNewDir("up"))
                {
                    body.transform.Rotate(90, 0, 0, Space.Self);
                    rotateCount--;
                }
                else if (checkNewDir("left") && checkOldDir("down"))
                {
                    if (index < moveCatScript.cat.Count - 1)
                    {
                        curveRight = transform.Find("CatCurveRight");
                        curveRight.gameObject.SetActive(true);
                        curveLeft = transform.Find("CatCurveLeft");
                        curveLeft.gameObject.SetActive(false);
                        curveFace = transform.Find("CatCurveFace");
                        curveFace.gameObject.SetActive(false);
                        standard = transform.Find("BodyPartStandard");
                        standard.gameObject.SetActive(false);
                        tail = transform.Find("CatTail");
                        tail.gameObject.SetActive(false);
                    }
                    
                    if(rotateCount > 1)
                    {
                        if (nextBody.checkNewDir("left"))
                        {
                            body.transform.Rotate(90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                        else
                        {
                            body.transform.Rotate(-90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                    }
                }
                else if (rotateCount == 1 && checkNewDir("left") && checkOldDir("left") && nextBody.checkNewDir("down"))
                {
                    body.transform.Rotate(-90, 0, 0, Space.Self);
                    rotateCount--;
                }
                else if (checkNewDir("up") && checkOldDir("right"))
                {
                    if (index < moveCatScript.cat.Count - 1)
                    {
                        curveRight = transform.Find("CatCurveRight");
                        curveRight.gameObject.SetActive(false);
                        curveLeft = transform.Find("CatCurveLeft");
                        curveLeft.gameObject.SetActive(true);
                        curveFace = transform.Find("CatCurveFace");
                        curveFace.gameObject.SetActive(false);
                        standard = transform.Find("BodyPartStandard");
                        standard.gameObject.SetActive(false);
                        tail = transform.Find("CatTail");
                        tail.gameObject.SetActive(false);
                    }
                    
                    if(rotateCount > 1)
                    {
                        if (nextBody.checkNewDir("up"))
                        {
                            body.transform.Rotate(-90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                        else
                        {
                            body.transform.Rotate(90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                    }
                }
                else if (rotateCount == 1 && checkNewDir("up") && checkOldDir("up") && nextBody.checkNewDir("right"))
                {
                    body.transform.Rotate(90, 0, 0, Space.Self);
                    rotateCount--;
                }
                else if (checkNewDir("up") && checkOldDir("left"))
                {
                    if (index < moveCatScript.cat.Count - 1)
                    {
                        curveRight = transform.Find("CatCurveRight");
                        curveRight.gameObject.SetActive(true);
                        curveLeft = transform.Find("CatCurveLeft");
                        curveLeft.gameObject.SetActive(false);
                        curveFace = transform.Find("CatCurveFace");
                        curveFace.gameObject.SetActive(false);
                        standard = transform.Find("BodyPartStandard");
                        standard.gameObject.SetActive(false);
                        tail = transform.Find("CatTail");
                        tail.gameObject.SetActive(false);
                    }
                    
                    if(rotateCount > 1)
                    {
                        if (nextBody.checkNewDir("up"))
                        {
                            body.transform.Rotate(90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                        else
                        {
                            body.transform.Rotate(-90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                    }
                }
                else if (rotateCount == 1 && checkNewDir("up") && checkOldDir("up") && nextBody.checkNewDir("left"))
                {
                    body.transform.Rotate(-90, 0, 0, Space.Self);
                    rotateCount--;
                }
                else if (checkNewDir("down") && checkOldDir("right"))
                {
                     if (index < moveCatScript.cat.Count - 1)
                     {
                        curveRight = transform.Find("CatCurveRight");
                        curveRight.gameObject.SetActive(true);
                        curveLeft = transform.Find("CatCurveLeft");
                        curveLeft.gameObject.SetActive(false);
                        curveFace = transform.Find("CatCurveFace");
                        curveFace.gameObject.SetActive(false);
                        standard = transform.Find("BodyPartStandard");
                        standard.gameObject.SetActive(false);
                        tail = transform.Find("CatTail");
                        tail.gameObject.SetActive(false);
                     }
                    
                    if(rotateCount > 1)
                    {
                        if (nextBody.checkNewDir("down"))
                        {
                            body.transform.Rotate(90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                        else
                        {
                            body.transform.Rotate(-90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                    }
                }
                else if (rotateCount == 1 && checkNewDir("down") && checkOldDir("down") && nextBody.checkNewDir("right"))
                {
                    body.transform.Rotate(-90, 0, 0, Space.Self);
                    rotateCount--;
                }
                else if (checkNewDir("down") && checkOldDir("left"))
                {
                    if (index < moveCatScript.cat.Count - 1)
                    {
                        curveRight = transform.Find("CatCurveRight");
                        curveRight.gameObject.SetActive(false);
                        curveLeft = transform.Find("CatCurveLeft");
                        curveLeft.gameObject.SetActive(true);
                        curveFace = transform.Find("CatCurveFace");
                        curveFace.gameObject.SetActive(false);
                        standard = transform.Find("BodyPartStandard");
                        standard.gameObject.SetActive(false);
                        tail = transform.Find("CatTail");
                        tail.gameObject.SetActive(false);
                    }
                    
                    if(rotateCount > 1)
                    {
                        if (nextBody.checkNewDir("down"))
                        {
                            body.transform.Rotate(-90, 0, 0, Space.Self);
                            rotateCount--;
                        }
                        else
                        {
                            body.transform.Rotate(90, 0, 0, Space.Self);
                            rotateCount--;
                        }   
                    }
                }
                else if (rotateCount == 1 && checkNewDir("down") && checkOldDir("down") && nextBody.checkNewDir("left"))
                {
                    body.transform.Rotate(90, 0, 0, Space.Self);
                    rotateCount--;
                }
            }
            //if this is the last body element rotate it right away
            if (index == moveCatScript.cat.Count -1  && checkNewDir("right") && checkOldDir("up"))
            {
                body.transform.Rotate(-90, 0, 0, Space.Self);
                rotateCount--;
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("right") && checkOldDir("down"))
            {
                body.transform.Rotate(90, 0, 0, Space.Self);
                rotateCount--;
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("left") && checkOldDir("up"))
            {
                body.transform.Rotate(90, 0, 0, Space.Self);
                rotateCount--;
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("left") && checkOldDir("down"))
            {
                body.transform.Rotate(-90, 0, 0, Space.Self);
                rotateCount--;
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("up") && checkOldDir("right"))
            {
                body.transform.Rotate(90, 0, 0, Space.Self);
                rotateCount--;
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("up") && checkOldDir("left"))
            {
                body.transform.Rotate(-90, 0, 0, Space.Self);
                rotateCount--;
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("down") && checkOldDir("right"))
            {
                body.transform.Rotate(-90, 0, 0, Space.Self);
                rotateCount--;
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("down") && checkOldDir("left"))
            {
                body.transform.Rotate(90, 0, 0, Space.Self); 
                rotateCount--;
            }
    }

    void OnTriggerEnter(Collider collision)
    {   //it sets changeFace on true when it detects a collision with an edge
        //it also sets canTurn on false so that we can't change direction when the head is on the collider
        if (collision.gameObject.tag == "Edge" && newDir == "right")
        {
            changeFace = true;
            changeFaceFront = true;
            canTurn = false;
        }
        
        else if (collision.gameObject.tag == "Edge" && newDir == "left")
        {
            canTurn = false;
            changeFace = true;
            changeFaceFront = true;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "up")
        {
            canTurn = false;
            changeFace = true;
            changeFaceFront = true;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "down")
        {
            canTurn = false;
            changeFace = true;
            changeFaceFront = true;
        }

    }

    void OnTriggerExit(Collider collision)
    {
        //at trigger exit we set the canTurn back to true so we can change direction
        //we also enque with the direction the head had so the camera can rotate in that direction
        if (collision.gameObject.tag == "Edge" && newDir == "right")
        {
            turnQ.Enqueue("right");
            canTurn = true;
            changeFace = false;
            changeFaceFront = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "left")
        {
            turnQ.Enqueue("left");
            canTurn = true;
            changeFace = false;
            changeFaceFront = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "up")
        {
            turnQ.Enqueue("up");
            canTurn = true;
            changeFace = false;
            changeFaceFront = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "down")
        {
            turnQ.Enqueue("down");
            canTurn = true;
            changeFace = false;
            changeFaceFront = false;
        }
    }

    public bool getCanTurn()
    {
        return canTurn;
    }
    public bool getChangeFace()
    {
        return changeFace;
    }
    public bool getTurnedHead()
    {
        return turned;
    }
    public void setChangeFace(bool var)
    {
        changeFace = var;
    }
    public void setTurnedHead(bool var)
    {
        turned = var;
    }
    public bool getChangeFaceFront()
    {
        return changeFaceFront;
    }
    public void setChangeFaceFront(bool val)
    {
        changeFaceFront = val;
    }
    public bool checkCanTurn(bool trn)
    {
        if (canTurn == trn)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool turQNotEmpty()
    {
        if(turnQ.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    //returns the direction that the camera must rotate towards
    public string cameraRotateDirection()
    {
        string direction = turnQ.Dequeue();
        return direction;
    }
    //this coroutine is used to delay the head rotation if the interval between the last move of the head and the head had to change direction is too small
    IEnumerator DelayTurn(float timer, ChangeDirection headDirections)
    {
        yield return new WaitForSeconds(0.05f - timer);
        switch (rotationType)
        {
            //daca vezi ca mai apare bug-ul ala fa sa se roteasca doar daca nu e pe collider
            case 1:

                if(!changeFace)
                {
                    transform.Rotate(-90, 0, 0, Space.Self);
                    transform.position += transform.TransformDirection (Vector3.up);
                    headDirections.setNewDir("right");
                    headDirections.setOldDir("up");
                    moveCatScript.SetTurnedHeadList();
                    turned = true;
                    turnAgainTimer = 0.0f;
                }
                break;
                
            case 2:
                if(!changeFace)
                {
                    transform.Rotate(90, 0, 0, Space.Self);
                    transform.position += transform.TransformDirection (Vector3.up);
                    headDirections.setNewDir("right");
                    headDirections.setOldDir("down");
                    moveCatScript.SetTurnedHeadList();
                    turned = true;
                    turnAgainTimer = 0.0f;
                    }
                break;
            case 3:
                if(!changeFace)
                {
                    transform.Rotate(90, 0, 0, Space.Self);
                    transform.position += transform.TransformDirection (Vector3.up);
                    headDirections.setNewDir("left");
                    headDirections.setOldDir("up");
                    moveCatScript.SetTurnedHeadList();
                    turned = true;
                    turnAgainTimer = 0.0f;
                }
                break;
                
            case 4:
                if(!changeFace)
                {
                    transform.Rotate(-90, 0, 0, Space.Self);
                    transform.position += transform.TransformDirection (Vector3.up);
                    headDirections.setNewDir("left");
                    headDirections.setOldDir("down");
                    moveCatScript.SetTurnedHeadList();
                    turned = true;
                    turnAgainTimer = 0.0f;
                }
                break;
            case 5:
                if(!changeFace)
                {
                    transform.Rotate(90, 0, 0, Space.Self);
                    transform.position += transform.TransformDirection (Vector3.up);
                    headDirections.setNewDir("up");
                    headDirections.setOldDir("right");
                    moveCatScript.SetTurnedHeadList();
                    turned = true;
                    turnAgainTimer = 0.0f;
                }
                break;
            case 6:
                if(!changeFace)
                {
                    transform.Rotate(-90, 0, 0, Space.Self);
                    transform.position += transform.TransformDirection (Vector3.up);
                    headDirections.setNewDir("up");
                    headDirections.setOldDir("left");
                    moveCatScript.SetTurnedHeadList();
                    turned = true;
                    turnAgainTimer = 0.0f;
                }
                break;
            case 7:
                if(!changeFace)
                {
                    transform.Rotate(-90, 0, 0, Space.Self);
                    transform.position += transform.TransformDirection (Vector3.up);
                    headDirections.setNewDir("down");
                    headDirections.setOldDir("right");
                    moveCatScript.SetTurnedHeadList();
                    turned = true;
                    turnAgainTimer = 0.0f;
                }
                break;
            case 8:
                if(!changeFace)
                {
                    transform.Rotate(90, 0, 0, Space.Self);
                    transform.position += transform.TransformDirection (Vector3.up);
                    headDirections.setNewDir("down");
                    headDirections.setOldDir("left");
                    moveCatScript.SetTurnedHeadList();
                    turned = true;
                    turnAgainTimer = 0.0f;
                }
                break;

            
        }
    }
    private void TurnAgain()
    {
        turnAgainTimer += Time.deltaTime;
    }

    public void setDirectionForNew(ChangeDirection oldLastBody)
    {
        newDir = oldLastBody.getNewDir();
        oldDir = oldLastBody.getOldDir();
    }

    

    
}
