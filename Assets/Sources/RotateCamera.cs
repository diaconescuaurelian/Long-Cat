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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        CameraTurn();
        finished = true;
    }

    void CameraTurn()
    {
        if (snakeHead.GetComponent<Move>().turn == true && snakeHead.GetComponent<Move>().right == true && finished == true)
        {   
            StartCoroutine(Rotate(Vector3.up, -90, 0.3f));
        }
        else if (snakeHead.GetComponent<Move>().turn == true && snakeHead.GetComponent<Move>().left == true && finished == true)
        {
            StartCoroutine(Rotate(Vector3.up, 90, 0.3f));
        }
        else if (snakeHead.GetComponent<Move>().turn == true && snakeHead.GetComponent<Move>().up == true && finished == true)
        {
            StartCoroutine(Rotate(Vector3.forward, -90, 0.3f));
        }
        else if (snakeHead.GetComponent<Move>().turn == true && snakeHead.GetComponent<Move>().down == true && finished == true)
        {
            StartCoroutine(Rotate(Vector3.forward, 90, 0.3f));
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
