using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    /*
    GameObject move_cam;
    GameObject cat_head;
    GameObject cat_body_part;
    public float distance = -1.0f;
    float timer = 0f;
    public static float moveTime = 0.9f;
    public static float quickMoveTime = 0.15f;
    public List<GameObject> cat = new List<GameObject>();

    public bool quickTurn = false;

    // Start is called before the first frame update
    void Awake()
    {
        cat_head = GameObject.FindGameObjectWithTag("Head");
        cat_body_part = GameObject.FindGameObjectWithTag("Body");
        move_cam = GameObject.FindGameObjectWithTag("MainCamera");
        //setting the directions of the initial elements of the list
        for (int i = 1; i < cat.Count; i++)
        {
            if (i - 1 == 0)
            {
                if (cat[i-1].GetComponent<Move>().right == true)
                {
                        cat[i].GetComponent<Body>().old_direction = "right";
                        cat[i].GetComponent<Body>().new_direction = "right";
                }
                else if (cat[i-1].GetComponent<Move>().left == true)
                {
                        cat[i].GetComponent<Body>().old_direction = "left";
                        cat[i].GetComponent<Body>().new_direction = "left";
                }
                else if (cat[i-1].GetComponent<Move>().up == true)
                {
                        cat[i].GetComponent<Body>().old_direction = "up";
                        cat[i].GetComponent<Body>().new_direction = "up";
                }
                else if (cat[i-1].GetComponent<Move>().down == true)
                {
                        cat[i].GetComponent<Body>().old_direction = "down";
                        cat[i].GetComponent<Body>().new_direction = "down";
                }
            }
            else if (i - 1 > 0)
            {
                cat[i].GetComponent<Body>().old_direction = cat[i - 1].GetComponent<Body>().old_direction;
                cat[i].GetComponent<Body>().new_direction = cat[i - 1].GetComponent<Body>().old_direction;
            }
            cat[i].GetComponent<Body>().rotate_count = 0;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer == cat_head.GetComponent<Move>().timer)
        {
            Debug.Log("Egale");
        }
        MoveBody();
        //ChangeFirstBodyDirection();
        //QuickDirection();
        Direction();
        //Mai trebuie sa fac o functie care sa dea enable si disable la prefaburi 
        //pentru cand o sa introduc modelele 3d cu pisica
        //Mai trebuie sa fac sa treaca pe alte fete ale cubului
    }
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
    
void ChangeFirstBodyDirection()
{
    if (cat[0].GetComponent<Move>().turning.Count > 0)
    {   
        quickTurn = true;
        //if the direction of the head is right
        if (cat[0].GetComponent<Move>().right == true)
        {
            cat[1].GetComponent<Body>().old_direction = cat[1].GetComponent<Body>().new_direction;
            cat[1].GetComponent<Body>().new_direction = "right";
            if (cat[1].GetComponent<Body>().old_direction != cat[1].GetComponent<Body>().new_direction)
            {
                cat[1].GetComponent<Body>().rotate_count ++;
            }
            if (cat[1].GetComponent<Body>().rotate_count > 0)
            {
                if (cat[1].GetComponent<Body>().new_direction == "right" && cat[1].GetComponent<Body>().old_direction == "up")
                {
                    cat[1].transform.Rotate(-90, 0, 0, Space.Self);
                    cat[0].GetComponent<Move>().turning.Dequeue();
                    cat[1].GetComponent<Body>().rotate_count --;
                }
                else if (cat[1].GetComponent<Body>().new_direction == "right" && cat[1].GetComponent<Body>().old_direction == "down")
                {
                    cat[1].transform.Rotate(90, 0, 0, Space.Self);
                    cat[0].GetComponent<Move>().turning.Dequeue();
                    cat[1].GetComponent<Body>().rotate_count --;
                }
            }
        }
        
        //if the direction of the head is left
        else if (cat[0].GetComponent<Move>().left == true)
        {
            cat[1].GetComponent<Body>().old_direction = cat[1].GetComponent<Body>().new_direction;
            cat[1].GetComponent<Body>().new_direction = "left";
            if (cat[1].GetComponent<Body>().old_direction != cat[1].GetComponent<Body>().new_direction)
            {
                cat[1].GetComponent<Body>().rotate_count ++;
            }
            if (cat[1].GetComponent<Body>().rotate_count > 0)
            {
                if (cat[1].GetComponent<Body>().new_direction == "left" && cat[1].GetComponent<Body>().old_direction == "up")
                {
                    cat[1].transform.Rotate(90, 0, 0, Space.Self);
                    cat[0].GetComponent<Move>().turning.Dequeue();
                    cat[1].GetComponent<Body>().rotate_count --;
                }
                else if (cat[1].GetComponent<Body>().new_direction == "left" && cat[1].GetComponent<Body>().old_direction == "down")
                {
                    cat[1].transform.Rotate(-90, 0, 0, Space.Self);
                    cat[0].GetComponent<Move>().turning.Dequeue();
                    cat[1].GetComponent<Body>().rotate_count --;
                }
            }
        }

        //if the direction of the head is up
        else if (cat[0].GetComponent<Move>().up == true)
        {
            cat[1].GetComponent<Body>().old_direction = cat[1].GetComponent<Body>().new_direction;
            cat[1].GetComponent<Body>().new_direction = "up";
            if (cat[1].GetComponent<Body>().old_direction != cat[1].GetComponent<Body>().new_direction)
            {
                cat[1].GetComponent<Body>().rotate_count ++;
            }
            if (cat[1].GetComponent<Body>().rotate_count > 0)
            {
                if (cat[1].GetComponent<Body>().new_direction == "up" && cat[1].GetComponent<Body>().old_direction == "right")
                {
                    cat[1].transform.Rotate(90, 0, 0, Space.Self);
                    cat[0].GetComponent<Move>().turning.Dequeue();
                    cat[1].GetComponent<Body>().rotate_count --;
                }
                else if (cat[1].GetComponent<Body>().new_direction == "up" && cat[1].GetComponent<Body>().old_direction == "left")
                {
                    cat[1].transform.Rotate(-90, 0, 0, Space.Self);
                    cat[0].GetComponent<Move>().turning.Dequeue();
                    cat[1].GetComponent<Body>().rotate_count --;
                }
            }
        }

        //if the direction of the head is down
        else if (cat[0].GetComponent<Move>().down == true)
        {
            cat[1].GetComponent<Body>().old_direction = cat[1].GetComponent<Body>().new_direction;
            cat[1].GetComponent<Body>().new_direction = "down";
            if (cat[1].GetComponent<Body>().old_direction != cat[1].GetComponent<Body>().new_direction)
            {
                cat[1].GetComponent<Body>().rotate_count ++;
            }
            if (cat[1].GetComponent<Body>().rotate_count > 0)
            {
                if (cat[1].GetComponent<Body>().new_direction == "down" && cat[1].GetComponent<Body>().old_direction == "right")
                {
                    cat[1].transform.Rotate(270, 0, 0, Space.Self);
                    cat[1].GetComponent<Body>().rotate_count --;
                }
                else if (cat[1].GetComponent<Body>().new_direction == "down" && cat[1].GetComponent<Body>().old_direction == "left")
                {
                    cat[1].transform.Rotate(-270, 0, 0, Space.Self);
                    cat[1].GetComponent<Body>().rotate_count --;
                }
            }
        }
                
    }
}

    //se misca bine pe alte fete dar acum e un delay
    //dupa ce apas space delay-ul dispare
    //vezi unde poti activa ceva sa se opreasca delay-ul ca si bum ai apasa pe space
    void MoveBody()
    {
        QuickDirection();
        for (int i = 1; i < cat.Count; i++)
        {
            //vezi unde faci dequeue
            //poate pui o variabila bool colliding care sa fie true doar cat timp colizioneaza
            //apoi verifici variabila aia
            if (!quickTurn && cat[0].GetComponent<Move>().turning.Count == 0)
            {
                cat[1].transform.position = cat[0].transform.position + cat[0].transform.up * distance;
            }
            
            if (i - 1 > 0 && cat[i - 1].GetComponent<Body>().on_edge)
            {
                //Debug.Log("Muta forward");
                cat[i].transform.position = cat[i-1].transform.position + cat[i-1].transform.right * (- distance);
            }
            // in if-ul asta am de modificat 
            /*
            else if (i - 1 > 0 && cat[i].GetComponent<Body>().on_edge)
            {
                if (cat[i].GetComponent<Body>().new_direction == cat[i].GetComponent<Body>().old_direction && cat[i].GetComponent<Body>().on_edge && cat[i - 1].GetComponent<Body>().new_direction == "right")
                cat[i].transform.Rotate(0, -90, 90, Space.Self);
                if (i + 1 < cat.Count)
                {
                    if (cat[i + 1].GetComponent<Body>().new_direction == cat[i].GetComponent<Body>().new_direction)
                    {
                        //cat[i + 1].transform.position = cat[i].transform.position + cat[i].transform.right * distance;
                        //cat[i].transform.Rotate(0, 0, 90, Space.Self);
                        cat[i + 1].transform.Rotate(0, 0, 90, Space.Self);
                    }
                }
                cat[i].GetComponent<Body>().on_edge = false;
            }
            
            else
            { 
               //Debug.Log("Muta up");
                cat[i].transform.position = cat[i-1].transform.position + cat[i-1].transform.up * distance;
            }

            
            
        }
    }
    
    void Direction()
    {
        timer += 1* Time.deltaTime;
        if (timer > moveTime)
        {
            ChangeDirection();
            timer = 0;
        }
        else if ((Input.GetKey(KeyCode.Space) && timer > quickMoveTime))
        {
            ChangeDirection();
            timer = 0;
        }
    }
    void QuickDirection()
    {
        if (cat[0].GetComponent<Move>().turning.Count > 0)
        {
            ChangeDirection();
            quickTurn = true;
            cat[0].GetComponent<Move>().turning.Dequeue();
            StartCoroutine(WaitToMove());
        }
        

    }

    IEnumerator WaitToMove()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            yield return new WaitForSeconds(0.15f);
            Debug.Log("quickturned");
            quickTurn = false;
        }
        else
        {
            yield return new WaitForSeconds(0.9f);
            Debug.Log("quickturned Normal");
            quickTurn = false;
        }

    }
    
    // Am facut sa nu se mai pozitioneze pe aceeasi linie cu capul cand schimb repede la 180 de grade asa ||
    // prima linie fiind restul corpului ce se indreapta in sus iar a doua fiind capul + ce mai vine dupa corp
    //incearca sa faci cumva ca in quickdirection sa se apeleze o functie care pe cap sa nu il roteasca, doar sa seteze count de rotatii
    //eventual change direction sa roteasca primul element dupa cap doar daca ceva boolean e pe false, care e pe true in quick
    //deci daca nu e quickdir roteste-l daca e nevoie, daca e quicdir doar seteaza countul
    //countul il cresti in quick si il scazi in normal

    */
}
