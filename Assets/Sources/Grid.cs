using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public GameObject food;
    private Vector3[,] grid1 = new Vector3[16, 16];
    private Vector3[,] grid2 = new Vector3[16, 16];
    private Vector3[,] grid3 = new Vector3[16, 16];
    private Vector3[,] grid4 = new Vector3[16, 16];
    private Vector3[,] grid5 = new Vector3[16, 16];
    private Vector3[,] grid6 = new Vector3[16, 16];

    
    // Start is called before the first frame update
    void Start()
    {
        float y = 15.5f;
        for (int i = 0; i < 16 ; i++)
        {
            float z = -7.5f;
            for (int j = 0; j < 16; j++)
            {
                grid1[i,j] = new Vector3(-8, y, z);
                z++;
            }
            y--;
        }
        
        int randi = Random.Range(0, 16);
        int randj = Random.Range(0, 16);
        Instantiate(food, grid1[randi, randj], Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
