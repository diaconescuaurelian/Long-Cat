using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Body
{
    public float timer = 0f;
    private static float moveTime = 0.9f;
    private static float quickMoveTime = 0.15f;
    private int distance = -1;
    public List<GameObject> cat = new List<GameObject>();
    private List<Body> bodyComponents = new List<Body>();
    private GameObject catObject;
    private MoveCat moveCatScript;
    private bool moved;

    private bool turnBody;
    private bool positionRight;


    void Awake()
    {
        catObject = GameObject.FindGameObjectWithTag("LongCat");
        moveCatScript = catObject.GetComponent<MoveCat>();
    }

    // Method that will be used to move the head in its up direction with 1 unit at every 0.9 or 0.15 if space key is pressed.
    public void MoveHead(GameObject head, bool changeFace, string newDir, bool turned)//capul se muta bine pe alte fete, mai trebuie modificat pentru body elements
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && turned)
        {
            if (timer > 0.10f)
            {
                timer = 0.10f;
            }
        }
        //incearca eventual sa verifici daca justTurned e true si daca e 
        //verifica daca timerul e mai mare de o anumita valoare sau interval gen daca timerul > 0.10
        //dar in timp ce space-ul e apasat
        //atunci fa timerul 0.10 ca sa-i dai timp sa ia valoarea change face corecta
        if (Input.GetKey(KeyCode.Space) && timer > quickMoveTime)
        {
            //head.transform.position += transform.TransformDirection (Vector3.up);
            //Debug.Log(changeFace);
            if (changeFace)
            { 
                head.transform.position += transform.TransformDirection (Vector3.right);
                transform.Rotate(0, 0, -90, Space.Self);
                //next.incrementCounter();
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
        else if (timer > moveTime)
        {
            //Debug.Log("changeFace is " + changeFace);
            //head.transform.position += transform.TransformDirection (Vector3.up);
            if (changeFace)
            { 
                head.transform.position += transform.TransformDirection (Vector3.right);
                transform.Rotate(0, 0, -90, Space.Self);
                //aici incrementeaza contorul body-ului de dupa el
                //next.incrementCounter();
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

    // primeste scriptul body-ului curent si body-ului din spatele lui pentru a putea verifica si modifica in scriptul asta flag-urile pentru a roti pentru mutarea pe alta fata
    public void MoveBody(GameObject body, GameObject front, bool changeFace, bool changeFaceFront, bool frontNotHead, ChangeDirection previous, ChangeDirection next)
    {
        /*
        fa ceva gen
        if (contor ==1)
        {
            contor++;
        }
        if (contor == 2)
        {
            //roteste 
            transform.Rotate(0, 0, -90, Space.Self);
            muta
            body.transform.position = front.transform.position + front.transform.up * distance;
            incrementeaza contorul body-ului din spatele lui
            next.incrementCounter();
            reseteaza propriul contor la 0
            contor = 0;
        }
        if (contor == 0)
        {
            muta 
        }
        */
        //daca elementul din fata e head, si queue-ul head-ului care isi face enqueue la intrarea pe collider nu este empty
        
        
        if(changeFace)
        {
            //body.transform.position += transform.TransformDirection (Vector3.right);
            transform.Rotate(0, 0, -90, Space.Self);  
            //Debug.Log("Schimb Fata");
        }
        else if (changeFaceFront && frontNotHead)
        {
            //Debug.Log("front element type is body: " + frontNotHead);
            body.transform.position = front.transform.position + front.transform.right * (- distance);
        }
        
        else
        {
            body.transform.position = front.transform.position + front.transform.up * distance;
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

    
}
