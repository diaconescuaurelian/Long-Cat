using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{

    GameObject snakeHead;
    public float speed = 90;
    public bool finished = true;
    void Awake()
    {
        snakeHead = GameObject.FindGameObjectWithTag("Head");
    }

    // Update is called once per frame
    void Update()
    {
        CameraTurn();
    }

    void CameraTurn()
    {
        if (snakeHead.GetComponent<Move>().turnQ.Count != 0)
        {  
            Debug.Log("countBefore: " + snakeHead.GetComponent<Move>().turnQ.Count);
            string direction = snakeHead.GetComponent<Move>().turnQ.Dequeue();
            Debug.Log("direction: " + direction);
            Debug.Log("countAfter: " + snakeHead.GetComponent<Move>().turnQ.Count);
            if (direction == "right")
            { 
                //finished = false;
                StartCoroutine(Rotate(Vector3.up, -90, 0.3f));
                //finished = true;
            }
            else if (direction == "left")
            {
                //finished = false;
                StartCoroutine(Rotate(Vector3.up, 90, 0.3f));
                //finished = true;
            }
            else if (direction == "up")
            {
                //finished = false;
                StartCoroutine(Rotate(Vector3.forward, -90, 0.3f));
                //finished = true;
            }
            else if (direction == "down")
            {
                //finished = false;
                StartCoroutine(Rotate(Vector3.forward, 90, 0.3f));
                //finished = true;
            }
        }
    }

    IEnumerator Rotate(Vector3 axis, float angle, float duration)
    {
        finished = false;
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);
        float elapsed = 0.0f;
        while( elapsed < duration )
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration );
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.rotation = to;
        finished = true;
    }
}
