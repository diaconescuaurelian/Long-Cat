using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    private string bodyType;
    protected string oldDir;
    protected string newDir;

    void Start()
    {

    }
    void Update()
    {
        
    }

    //These methods are setting the value of the private variables.
    public void SetBodyType(string type)
    {
        bodyType = type;
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
    //These methods return true if the variable that we check for is equal to the parameter that the methods are getting
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

    //This method returns true if the old dir is the same as the new dir
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
}
