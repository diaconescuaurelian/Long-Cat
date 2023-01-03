using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLines : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.blue;
        //2 parallel faces of the cube
        for (int i = -8, j = 16; i < 9 && j >= 0; i++, j--)
        {
            //drawing grid for the face 1
            Vector3 top1 = new Vector3(i, 16, -8);
            Vector3 down1 = new Vector3(i, 0, -8);
            Vector3 left1 = new Vector3(-8, j, -8);
            Vector3 right1 = new Vector3(8, j, -8);
            Gizmos.DrawLine(top1, down1);
            Gizmos.DrawLine(left1, right1);
            
            //drawing grid for the face 2
            Vector3 top2 = new Vector3(i, 16, 8);
            Vector3 down2 = new Vector3(i, 0, 8);
            Vector3 left2 = new Vector3(-8, j, 8);
            Vector3 right2 = new Vector3(8, j, 8);
            Gizmos.DrawLine(top2, down2);
            Gizmos.DrawLine(left2, right2);

            
        }

        //2 parallel faces of the cube
        for (int i = 8, j = 16; i >= -8 && j >= 0; i--, j--)
        {
            //drawing grid for the face 1
            Vector3 top1 = new Vector3(-8, 16, i);
            Vector3 down1 = new Vector3(-8, 0, i);
            Vector3 left1 = new Vector3(-8, j, 8);
            Vector3 right1 = new Vector3(-8, j, -8);
            Gizmos.DrawLine(left1, right1);
            Gizmos.DrawLine(top1, down1);

            //drawing grid for the face 1
            Vector3 top2 = new Vector3(8, 16, i);
            Vector3 down2 = new Vector3(8, 0, i);
            Vector3 left2 = new Vector3(8, j, 8);
            Vector3 right2 = new Vector3(8, j, -8);
            Gizmos.DrawLine(left2, right2);
            Gizmos.DrawLine(top2, down2);
        }

        //2 parallel faces of the cube
        for (int i = 8; i >= -8 ; i--)
        {
            //drawing grid for the face 1
            Vector3 top1 = new Vector3(i, 16, 8);
            Vector3 down1 = new Vector3(i, 16, -8);
            Vector3 left1 = new Vector3(-8, 16, i);
            Vector3 right1 = new Vector3(8, 16, i);
            Gizmos.DrawLine(left1, right1);
            Gizmos.DrawLine(top1, down1);

            //drawing grid for the face 1
            Vector3 top2 = new Vector3(i, 0, 8);
            Vector3 down2 = new Vector3(i, 0, -8);
            Vector3 left2 = new Vector3(-8, 0, i);
            Vector3 right2 = new Vector3(8, 0, i);
            Gizmos.DrawLine(left2, right2);
            Gizmos.DrawLine(top2, down2);
        }
    }
}
