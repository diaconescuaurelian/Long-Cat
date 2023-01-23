using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeDirection : Body
{
    GameObject head;
    Move headMoveComponent;
    private GameObject catObject;
    private MoveCat moveCatScript;
    public bool changeFace;
    public bool changeFaceFront;
    public bool canTurn = true;
    public Queue<string> turnQ = new Queue<string>();
    //private float timer = 0f;
    //private float moveTime = 0.9f;
    //private float quickMoveTime = 0.05f;
    public int rotateCount = 0;
    //bool changedHeadDirection = false;
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
        
    }
    // dupa ce apas dreapta si schimb directia head-ului pe new = right old = up
    // daca il las la mearga in continuare nu isi modifica pozitia ca new = right old = right

    //verifica daca in momentul in care s-a apasat o sageata si rotirea e valida
    //adica imediat ce ai  intrat in vreun if
    //daca space-ul e apasat si timer-ul din moveHead e > 0.12 sau < 0.03 asteapta ceva gen 0.05 sec si apoi fa opeatiile 
    public void TurnHead(GameObject head, ChangeDirection headDirections) 
    {   
        //changedHeadDirection = true;
        if (Input.GetKeyDown(KeyCode.RightArrow) && checkNewDir("up"))
        {
            //Debug.Log("Roteste dreapta");
            head.transform.Rotate(-90, 0, 0, Space.Self);
            head.transform.position += transform.TransformDirection (Vector3.up);
            headDirections.setNewDir("right");
            headDirections.setOldDir("up");
            moveCatScript.SetTurnedHeadList();
        }
        //Turn Right if facing down
        else if (Input.GetKeyDown(KeyCode.RightArrow) && checkNewDir("down"))
        {
            //Debug.Log("Roteste dreapta");
            head.transform.Rotate(90, 0, 0, Space.Self);
            head.transform.position += transform.TransformDirection (Vector3.up);
            headDirections.setNewDir("right");
            headDirections.setOldDir("down");
            moveCatScript.SetTurnedHeadList();
        }
        //Turn Left if facing up
        else if (Input.GetKeyDown(KeyCode.LeftArrow)  && checkNewDir("up"))
        {
            //Debug.Log("Roteste stanga");
            head.transform.Rotate(90, 0, 0, Space.Self);
            head.transform.position += transform.TransformDirection (Vector3.up);
            headDirections.setNewDir("left");
            headDirections.setOldDir("up");
            moveCatScript.SetTurnedHeadList();
        }
        //Turn Left if facing down
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && checkNewDir("down"))
        {
            //Debug.Log("Roteste stanga");
            head.transform.Rotate(-90, 0, 0, Space.Self);
            head.transform.position += transform.TransformDirection (Vector3.up);
            headDirections.setNewDir("left");
            headDirections.setOldDir("down");
            moveCatScript.SetTurnedHeadList();
        }
        //Turn Up if facing right
        else if (Input.GetKeyDown(KeyCode.UpArrow) &&  checkNewDir("right"))
        {
            head.transform.Rotate(90, 0, 0, Space.Self);
            head.transform.position += transform.TransformDirection (Vector3.up);
            headDirections.setNewDir("up");
            headDirections.setOldDir("right");
            moveCatScript.SetTurnedHeadList();
        }
        //Turn Up if facing left
        else if (Input.GetKeyDown(KeyCode.UpArrow) && checkNewDir("left"))
        {
            head.transform.Rotate(-90, 0, 0, Space.Self);
            head.transform.position += transform.TransformDirection (Vector3.up);
            headDirections.setNewDir("up");
            headDirections.setOldDir("left");
            moveCatScript.SetTurnedHeadList();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) &&  checkNewDir("right"))
        {
            head.transform.Rotate(-90, 0, 0, Space.Self);
            head.transform.position += transform.TransformDirection (Vector3.up);
            headDirections.setNewDir("down");
            headDirections.setOldDir("right");
            moveCatScript.SetTurnedHeadList();
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && checkNewDir("left"))
        {
            head.transform.Rotate(90, 0, 0, Space.Self);
            head.transform.position += transform.TransformDirection (Vector3.up);
            headDirections.setNewDir("down");
            headDirections.setOldDir("left");
            moveCatScript.SetTurnedHeadList();
        }
        /*
        else if (!checkIfDirIsChanged())
        {
            Debug.Log(checkIfDirIsChanged());
            oldDir = newDir;
        }
        */
    }
    // primesc ca parametrii body-ul pe care trebuie sa il rotesc si elementul front
    //incearca sa primesti 
    public void TurnBody(GameObject body, ChangeDirection nextBody, ChangeDirection front, int index)
    {
        moveCatScript.SetMovedHeadElement(index);
        moveCatScript.SetTurnedHeadElement(index);
        //Debug.Log(front.getNewDir() + " Turn Body");
        //for every bodypart of the cat starting from the one after the head
        /*
        if (checkOldDir("just started"))
        {
            oldDir = front.getOldDir();
            newDir = front.getOldDir();
        }
        else     // in loc de if else-ul asta fa ca atunci cand adaugi un element in lista, sa-i setezi si old dir si new dir
        {        //atentie, seteaza old dir si new dir pe un obiect referinta la componenta ChangeDirection a lor
            
            //changeHeadDirection = false;
            //headMoveComponent.setHeadHasMoved(false);
        }
        */
        if (front.checkBodyType("head")) 
            {
                //Debug.Log("primul body " + rotateCount);
                oldDir = newDir;
                newDir = front.getNewDir(); //pentru primul body trebuie sa iei newDir-ul de la head.
                //Debug.Log(newDir + " primul dupa");
            }
            else 
            {
                //Debug.Log(newDir + " restul inainte");
                oldDir = newDir;
                newDir = front.getOldDir(); //in mod normal trebuie sa iei old dir de la ala din fata
                //Debug.Log(newDir + " restul dupa");
            }
            
            if (checkIfDirIsChanged()) // is true when newDir != oldDir
            {
                rotateCount ++;
            }
            
            if (rotateCount > 0) 
            {
                //trebuie sa fac checkolddir si checknewdir pe o componenta ChangeDirections a lui body nu asa direct
                //ramane in if-ul asta chiar daca in inspector directia e buna
                if (checkNewDir("right") && checkOldDir("up")) 
                {
                    if(rotateCount > 1)// copiaza cazul asta si la celelalte cu directii diferite dar pune rotate-ul corect
                    {
                        body.transform.Rotate(-90, 0, 0, Space.Self);
                        rotateCount--;
                    }
                    /*
                    else if (bodyDirection.rotateCount == 1 && !checkIfDirIsChanged())
                    {
                        Debug.Log("Counter == 1:" + rotateCount);
                        body.transform.Rotate(-90, 0, 0, Space.Self);
                        bodyDirection.rotateCount--;
                    }
                    */
                    //Debug.Log("M-am rotit la dreapta " + rotateCount);
                }
                else if (rotateCount == 1 && checkNewDir("right") && checkOldDir("right") && nextBody.checkNewDir("up"))
                {
                    //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                    body.transform.Rotate(-90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                    rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
                }//ultimul element nu va avea un previous asa ca o sa trebuiasca sa mai fac un if in update si sa-l dau tot pe el ca previous
                //asa o sa aiba new dir pentru elementul din spatele lui egal cu new dir-ul lui evident
                //o sa mai fac un alt if in metoda asta in care daca new dir-ul aluia din spatele tau == cu new dirul tau si counter > 0 roteste direct
                else if (checkNewDir("right") && checkOldDir("down"))
                {
                    //Debug.Log("Am facut dreapta");
                    if(rotateCount > 1)// copiaza cazul asta si la celelalte cu directii diferite dar pune rotate-ul corect
                    {
                        body.transform.Rotate(90, 0, 0, Space.Self);
                        rotateCount--;
                    }
                    //body.transform.Rotate(90, 0, 0, Space.Self);
                    //rotateCount--;
                }
                else if (rotateCount == 1 && checkNewDir("right") && checkOldDir("right") && nextBody.checkNewDir("down"))
                {
                    //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                    body.transform.Rotate(90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                    rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
                }
                else if (checkNewDir("left") && checkOldDir("up"))
                {
                    //Debug.Log("Am facut stanga");
                    if(rotateCount > 1)// copiaza cazul asta si la celelalte cu directii diferite dar pune rotate-ul corect
                    {
                        body.transform.Rotate(90, 0, 0, Space.Self);
                        rotateCount--;
                    }
                    //body.transform.Rotate(90, 0, 0, Space.Self);
                    //rotateCount--;
                }
                else if (rotateCount == 1 && checkNewDir("left") && checkOldDir("left") && nextBody.checkNewDir("up"))
                {
                    //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                    body.transform.Rotate(90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                    rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
                }
                else if (checkNewDir("left") && checkOldDir("down"))
                {
                    //Debug.Log("Am facut stanga");
                    if(rotateCount > 1)// copiaza cazul asta si la celelalte cu directii diferite dar pune rotate-ul corect
                    {
                        body.transform.Rotate(-90, 0, 0, Space.Self);
                        rotateCount--;
                    }
                    //body.transform.Rotate(-90, 0, 0, Space.Self);
                    //rotateCount--;
                }
                else if (rotateCount == 1 && checkNewDir("left") && checkOldDir("left") && nextBody.checkNewDir("down"))
                {
                    //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                    body.transform.Rotate(-90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                    rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
                }
                else if (checkNewDir("up") && checkOldDir("right"))
                {
                    if(rotateCount > 1)// copiaza cazul asta si la celelalte cu directii diferite dar pune rotate-ul corect
                    {
                        body.transform.Rotate(90, 0, 0, Space.Self);
                        rotateCount--;
                    }
                    //body.transform.Rotate(90, 0, 0, Space.Self);
                    //rotateCount--;
                }
                else if (rotateCount == 1 && checkNewDir("up") && checkOldDir("up") && nextBody.checkNewDir("right"))
                {
                    //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                    body.transform.Rotate(90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                    rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
                }
                else if (checkNewDir("up") && checkOldDir("left"))
                {
                    if(rotateCount > 1)// copiaza cazul asta si la celelalte cu directii diferite dar pune rotate-ul corect
                    {
                        body.transform.Rotate(-90, 0, 0, Space.Self);
                        rotateCount--;
                    }
                    //body.transform.Rotate(-90, 0, 0, Space.Self);
                    //rotateCount--;
                }
                else if (rotateCount == 1 && checkNewDir("up") && checkOldDir("up") && nextBody.checkNewDir("left"))
                {
                    //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                    body.transform.Rotate(-90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                    rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
                }
                else if (checkNewDir("down") && checkOldDir("right"))
                {
                    //Debug.Log("Merem Jos");
                    if(rotateCount > 1)// copiaza cazul asta si la celelalte cu directii diferite dar pune rotate-ul corect
                    {
                        body.transform.Rotate(-90, 0, 0, Space.Self);
                        rotateCount--;
                    }
                    //body.transform.Rotate(-90, 0, 0, Space.Self);
                    //rotateCount--;
                }
                else if (rotateCount == 1 && checkNewDir("down") && checkOldDir("down") && nextBody.checkNewDir("right"))
                {
                    //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                    body.transform.Rotate(-90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                    rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
                }
                else if (checkNewDir("down") && checkOldDir("left"))
                {
                    //Debug.Log("Merem Jos");
                    if(rotateCount > 1)// copiaza cazul asta si la celelalte cu directii diferite dar pune rotate-ul corect
                    {
                        body.transform.Rotate(90, 0, 0, Space.Self);
                        rotateCount--;
                    }
                    //body.transform.Rotate(90, 0, 0, Space.Self);
                    //rotateCount--;
                }
                else if (rotateCount == 1 && checkNewDir("down") && checkOldDir("down") && nextBody.checkNewDir("left"))
                {
                    //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                    body.transform.Rotate(90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                    rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
                }
                //gandeste-te cum sa il rotesti pe ultimul
                //
                //
            }
            if (index == moveCatScript.cat.Count -1  && checkNewDir("right") && checkOldDir("up"))
            {
                //Debug.Log("ULTIMUL BODY RIGHT");
                //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                body.transform.Rotate(-90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("right") && checkOldDir("down"))
            {
                //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                body.transform.Rotate(90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("left") && checkOldDir("up"))
            {
                //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                body.transform.Rotate(90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("left") && checkOldDir("down"))
            {
                //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                body.transform.Rotate(-90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("up") && checkOldDir("right"))
            {
                //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                body.transform.Rotate(90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("up") && checkOldDir("left"))
            {
                //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                body.transform.Rotate(-90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("down") && checkOldDir("right"))
            {
                //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                body.transform.Rotate(-90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
            }
            else if (index == moveCatScript.cat.Count -1 && checkNewDir("down") && checkOldDir("left"))
            {
                //copiaza cazul asta pentru toate celelalte cazuri in care directiile sunt = si countul = 1 dar pune rotate-ul corect
                body.transform.Rotate(90, 0, 0, Space.Self); //trebuie sa vad cum fac sa mearga si cand vine de sus in jos si o ia catre dreapta
                rotateCount--;//eventual sa verific newdir pentru elementul din spatele lui si daca e Up fac -90 daca e down fac la 90
            }
    }

    void OnTriggerEnter(Collider collision)
    {
        //fara transform.position nu mai e bugul de pe margine
        //Debug.Log("Detectat coliziune");
        if (collision.gameObject.tag == "Edge" && newDir == "right")
        {
            changeFace = true;
            changeFaceFront = true;
            //transform.position += transform.TransformDirection (Vector3.right);
            //transform.Rotate(0, 0, -90, Space.Self);
            canTurn = false;
        }
        
        else if (collision.gameObject.tag == "Edge" && newDir == "left")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            canTurn = false;
            changeFace = true;
            changeFaceFront = true;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "up")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            canTurn = false;
            changeFace = true;
            changeFaceFront = true;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "down")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            canTurn = false;
            changeFace = true;
            changeFaceFront = true;
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Edge" && newDir == "right")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            turnQ.Enqueue("right");
            canTurn = true;
            changeFace = false;
            changeFaceFront = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "left")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            turnQ.Enqueue("left");
            canTurn = true;
            changeFace = false;
            changeFaceFront = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "up")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            turnQ.Enqueue("up");
            canTurn = true;
            changeFace = false;
            changeFaceFront = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "down")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
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
    public void setChangeFace(bool var)
    {
        changeFace = var;
    }
    public bool getChangeFaceFront()
    {
        return changeFaceFront;
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
    public string cameraRotateDirection()
    {
        string direction = turnQ.Dequeue();
        return direction;
    }

}
