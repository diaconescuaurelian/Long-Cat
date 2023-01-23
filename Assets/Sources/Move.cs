using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Body
{
    private float timer = 0f;
    private static float moveTime = 0.9f;
    private static float quickMoveTime = 0.15f;
    private int distance = -1;
    public List<GameObject> cat = new List<GameObject>();
    private List<Body> bodyComponents = new List<Body>();
    private GameObject catObject;
    private MoveCat moveCatScript;



    void Awake()
    {
        catObject = GameObject.FindGameObjectWithTag("LongCat");
        moveCatScript = catObject.GetComponent<MoveCat>();
        /*
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
        */
    }

    // Method that will be used to move the head in its up direction with 1 unit at every 0.9 or 0.15 if space key is pressed.
    public void MoveHead(GameObject head, bool changeFace, string newDir)//capul se muta bine pe alte fete, mai trebuie modificat pentru body elements
    {
        timer += Time.deltaTime;
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
            }
            //if it doesn't turn to another face of the cube
            else 
            {
                head.transform.position += transform.TransformDirection (Vector3.up);
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
    public void MoveBody(GameObject body, GameObject front, bool changeFace, bool changeFaceFront, bool frontNotHead)
    {
        //daca schimb directia cand e space apasat si nu a luat changeface la timp  nu il mai roteste la 90 de grade
        //Dar de ce nu se intampla can tin space si nu schimb directia? Sau cand schimb directia la viteza normala?
        //Un posibil raspuns ar putea tine de faptul ca daca tin space si schimb directia e posibil sa se schimbe 
        //directia la un interval foarte scurt de la momentul la care tocmai l-am mutat ?
        //As putea sa incerc sa fac ca daca 

        if(changeFace)
        {
            //body.transform.position += transform.TransformDirection (Vector3.right);
            transform.Rotate(0, 0, -90, Space.Self);  
            Debug.Log("Schimb Fata");
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

    /*
    GameObject move_cam;
    private float timer = 0f;
    private static float moveTime = 0.9f;
    private static float quickMoveTime = 0.15f;
    public string oldDir;
    public string newDir;
    private bool can_turn;
    private Queue<string> turnQ = new Queue<string>();
    bool change_face = false;
    private Queue<string> turning = new Queue<string>();
    void Awake()
    {
        move_cam = GameObject.FindGameObjectWithTag("MainCamera");
        can_turn = true;
    }
    void Start()
    {
        newDir = "up";
        oldDir = "up";
    }
    void Update()
    {
        //if (move_cam.GetComponent<RotateCamera>().finished == true)
        //{
            TurnHead();
            //MoveHead();
        //}
        MoveHead();
        //daca move head e in if se face un delay
        //cum fac sa astepte si body parts
    }
    //When facing a direction and colliding with an edge, turn 90 degrees and move forward 1 unit
    void OnTriggerEnter(Collider collision)
    {
        //fara transform.position nu mai e bugul de pe margine
        if (collision.gameObject.tag == "Edge" && newDir == "right")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            can_turn = false;
            change_face = true;
        }
        
        else if (collision.gameObject.tag == "Edge" && newDir == "left")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            can_turn = false;
            change_face = true;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "up")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            can_turn = false;
            change_face = true;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "down")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            can_turn = false;
            change_face = true;
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Edge" && newDir == "right")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            turnQ.Enqueue("right");
            can_turn = true;
            change_face = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "left")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            turnQ.Enqueue("left");
            can_turn = true;
            change_face = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "up")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            turnQ.Enqueue("up");
            can_turn = true;
            change_face = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "down")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            turnQ.Enqueue("down");
            can_turn = true;
            change_face = false;
        }
    }
    //Function that moves the head of the cat
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
            
            
            timer = 0;
        }
    }
    //Function that turns the head of the cat
    void TurnHead()
    {   
        if (can_turn)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && newDir == "up")
            {
            turning.Enqueue("turned");
            transform.Rotate(-90, 0, 0, Space.Self);
            if (Input.GetKey(KeyCode.Space) && (quickMoveTime -timer) > 0.10f)
            {
                transform.position += transform.TransformDirection (Vector3.up);
            }
            else if (!Input.GetKey(KeyCode.Space))
            {
                transform.position += transform.TransformDirection (Vector3.up);
            }
            newDir = "right";
            oldDir = "up";
            }
            //Turn Right if facing down
            if (Input.GetKeyDown(KeyCode.RightArrow) && newDir == "down")
            {
                turning.Enqueue("turned");
                transform.Rotate(90, 0, 0, Space.Self);
                if (Input.GetKey(KeyCode.Space) && (quickMoveTime -timer) > 0.10f)
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                else if (!Input.GetKey(KeyCode.Space))
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                newDir = "right";
                oldDir = "down";
            }
            //Turn Left if facing up
            if (Input.GetKeyDown(KeyCode.LeftArrow)  && newDir == "up")
            {
                turning.Enqueue("turned");
                transform.Rotate(90, 0, 0, Space.Self);
                if (Input.GetKey(KeyCode.Space) && (quickMoveTime -timer) > 0.10f)
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                else if (!Input.GetKey(KeyCode.Space))
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                newDir = "left";
                oldDir = "up";
            }
            //Turn Left if facing down
            if (Input.GetKeyDown(KeyCode.LeftArrow) && newDir == "down")
            {
                turning.Enqueue("turned");
                transform.Rotate(-90, 0, 0, Space.Self);
                if (Input.GetKey(KeyCode.Space) && (quickMoveTime -timer) > 0.05f)
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                else if (!Input.GetKey(KeyCode.Space))
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                newDir = "left";
                oldDir = "down";
            }
            //Turn Up if facing right
            if (Input.GetKeyDown(KeyCode.UpArrow) &&  newDir == "right")
            {
                turning.Enqueue("turned");
                transform.Rotate(90, 0, 0, Space.Self);
                if (Input.GetKey(KeyCode.Space) && (quickMoveTime -timer) > 0.05f)
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                else if (!Input.GetKey(KeyCode.Space))
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                newDir = "up";
                oldDir = "right";
            }
            //Turn Up if facing left
            if (Input.GetKeyDown(KeyCode.UpArrow) && newDir == "left")
            {
                turning.Enqueue("turned");
                transform.Rotate(-90, 0, 0, Space.Self);
                if (Input.GetKey(KeyCode.Space) && (quickMoveTime -timer) > 0.05f)
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                else if (!Input.GetKey(KeyCode.Space))
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                newDir = "up";
                oldDir = "left";
            }
            //Turn Down if facing 
            if (Input.GetKeyDown(KeyCode.DownArrow) &&  newDir == "right")
            {
                turning.Enqueue("turned");
                transform.Rotate(-90, 0, 0, Space.Self);
                if (Input.GetKey(KeyCode.Space) && (quickMoveTime -timer) > 0.05f)
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                else if (!Input.GetKey(KeyCode.Space))
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                newDir = "down";
                oldDir = "right";
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && newDir == "left")
            {
                turning.Enqueue("turned");
                transform.Rotate(90, 0, 0, Space.Self);
                if (Input.GetKey(KeyCode.Space) && (quickMoveTime -timer) > 0.05f)
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                else if (!Input.GetKey(KeyCode.Space))
                {
                    transform.position += transform.TransformDirection (Vector3.up);
                }
                newDir = "down";
                oldDir = "left";
            }
        }
        
    }
    */
}
