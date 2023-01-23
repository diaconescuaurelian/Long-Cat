using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCylinder : MonoBehaviour
{
    public float moveInterval = 1f; // time interval between each move
    private float timeSinceLastMove = 0f; // time passed since last move
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        timeSinceLastMove += Time.deltaTime;
        if (timeSinceLastMove >= moveInterval)
        {
            rb.MovePosition(transform.position + transform.forward);
            timeSinceLastMove = 0;
        }
    }
}
