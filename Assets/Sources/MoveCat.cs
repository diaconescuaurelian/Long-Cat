using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCat : Body
{
    public List<GameObject> cat = new List<GameObject>();
    private List<Body> bodyScriptComponents = new List<Body>();
    private List<Move> moveScriptComponents = new List<Move>();
    private List<ChangeDirection> changeDirScriptComponents = new List<ChangeDirection>();
    private List<bool> headMoved = new List<bool>();
    private List<bool> headTurned = new List<bool>();
    void Awake()
    {
         foreach (GameObject body in cat)
        {
            Body bodyPart = body.GetComponent<Body>();
            bodyScriptComponents.Add(bodyPart);
            Move movePart = body.GetComponent<Move>();
            moveScriptComponents.Add(movePart);
            ChangeDirection changeDir = body.GetComponent<ChangeDirection>();
            changeDirScriptComponents.Add(changeDir);
            headMoved.Add(false);
            headTurned.Add(false);
        }

        for (int i = 0; i < cat.Count; i++)
        {
            if (i == 0)
            {
                bodyScriptComponents[i].SetBodyType("head");
                changeDirScriptComponents[i].SetBodyType("head");
            }
            else
            {
                bodyScriptComponents[i].SetBodyType("body");
                changeDirScriptComponents[i].SetBodyType("body");
            }
            changeDirScriptComponents[i].setNewDir("up");
            changeDirScriptComponents[i].setOldDir("up");
        }

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cat.Count; i++)
        {
            if (bodyScriptComponents[i].checkBodyType("head"))
            {
                moveScriptComponents[i].MoveHead(cat[i],changeDirScriptComponents[i].getChangeFace(), changeDirScriptComponents[i].getNewDir(), changeDirScriptComponents[i].getTurnedHead());
                if (changeDirScriptComponents[i].getTurnedHead())
                {
                    changeDirScriptComponents[i].setTurnedHead(false);
                }
                if (changeDirScriptComponents[i].getCanTurn())
                {
                    changeDirScriptComponents[i].TurnHead(cat[i], changeDirScriptComponents[i], moveScriptComponents[i]);
                }
                if (moveScriptComponents[i].getMoved())
                {
                    moveScriptComponents[i].setMoved(false);
                }
            }
            else if (bodyScriptComponents[i].checkBodyType("body"))
            {
                moveScriptComponents[i].MoveBody(cat[i], cat[i - 1], changeDirScriptComponents[i].getChangeFace(), changeDirScriptComponents[i - 1].getChangeFaceFront(), bodyScriptComponents[i - 1].checkBodyType("body"), changeDirScriptComponents[i], changeDirScriptComponents[i - 1] ) ;
                if (changeDirScriptComponents[i].getChangeFace())
                {
                    changeDirScriptComponents[i].setChangeFace(false);
                    changeDirScriptComponents[i - 1].setChangeFaceFront(false);
                }
                if (headMoved[i] || headTurned[i])
                {
                    if (i + 1 < changeDirScriptComponents.Count)
                    {
                        changeDirScriptComponents[i].TurnBody(cat[i], changeDirScriptComponents[i + 1], changeDirScriptComponents[i - 1], i);
                    }
                    else if (i + 1 == changeDirScriptComponents.Count)
                    {
                        //Debug.Log("ULTIMUL BODY");
                        changeDirScriptComponents[i].TurnBody(cat[i], changeDirScriptComponents[i], changeDirScriptComponents[i - 1], i);
                    }
                    
                }
            }
        }
    }
    public void SetTurnedHeadList()
    {
        for (int i = 0; i < headTurned.Count; i++)
        {
            headTurned[i] = true;
        }
    }
    public void SetMovedHeadList()
    {
        for (int i = 0; i < headMoved.Count; i++)
        {
            headMoved[i] = true;
        }
    }

    public void SetTurnedHeadElement(int i)
    {
        headTurned[i] = false;
    }
    public void SetMovedHeadElement(int i)
    {
        headMoved[i] = false;
    }
    public void AddNewScriptComponents(Body newBodyScript, Move newMoveScript, ChangeDirection newChangeDirectionScript)
    {
        bodyScriptComponents.Add(newBodyScript);
        moveScriptComponents.Add(newMoveScript);
        changeDirScriptComponents.Add(newChangeDirectionScript);
        headMoved.Add(true);
        headTurned.Add(true);
    }

}
