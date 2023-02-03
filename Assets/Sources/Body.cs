using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public string bodyType;
    public string oldDir;
    public string newDir;

    void Start()
    {

    }
    void Update()
    {
        
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

    public void SetBodyType(string type)
    {
        bodyType = type;
    }

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

    //This function returns true if the old dir is the same as the new dir
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
