using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFace : MoveCat//daca o fac derivata din MoveCat
{
    //o sa fac functii de get list in Move cat si o sa pot apela metodele aici ca sa iau changeDirElement
    //private bool changeFace;
    //private bool canTurn;
    //private string newDir;
    // daca intra in coliziune pune changeFace = true
    //daca changeFace == true atunci in loc sa mut in directia up mut in directia right
    //fa o metoda checkChangeFace si reintro du onEdge pentru moveBody
    //acceseaza changeFace si onEdge
    //canTurn si changeFace trebuie sa fie accesati in move
    // o posibila idee e sa fac inca o lista in MoveCat cu scripturi changeFace pentru toate elementele
    //trimite changeFace si canTurn ca parametrii pentru MoveBody si MoveHead
    //gandeste-te cum accesezi newDir al fiecarui element corespunzator in scriptul asta
//--------------------------------------------------------------------------------------------
    // sau poate asta sa fie direct in clasa ChangeDirection ca sa acceseze directia fiecarui element exact cum trebuie
    //in movecat cand apelez moveHead si moveBody sa dau ca parametri si can Turn si changeFace care se afla in ala
    /*
    void OnTriggerEnter(Collider collision)
    {
        //fara transform.position nu mai e bugul de pe margine
        if (collision.gameObject.tag == "Edge" && newDir == "right")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            canTurn = false;
            changeFace = true;
        }
        
        else if (collision.gameObject.tag == "Edge" && newDir == "left")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            canTurn = false;
            changeFace = true;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "up")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            canTurn = false;
            changeFace = true;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "down")
        {
            transform.Rotate(0, 0, -90, Space.Self);
            canTurn = false;
            changeFace = true;
        }

    }

    void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Edge" && newDir == "right")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            //turnQ.Enqueue("right");
            canTurn = true;
            changeFace = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "left")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            //turnQ.Enqueue("left");
            canTurn = true;
            changeFace = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "up")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            //turnQ.Enqueue("up");
            canTurn = true;
            changeFace = false;
        }

        else if (collision.gameObject.tag == "Edge" && newDir == "down")
        {
            //transform.Rotate(0, 0, -90, Space.Self);
            //turnQ.Enqueue("down");
            canTurn = true;
            changeFace = false;
        }
    }
    */
}
