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
        //fata 1
        float y = 15.5f;
        for (int i = 0; i < 16 ; i++)
        {
            float z = -7.5f;
            for (int j = 0; j < 16; j++)
            {
                grid1[i,j] = new Vector3(-8.5f, y, z);
                z++;
            }
            y--;
        }
        //fata 2
        y = 15.5f;
        for (int i = 0; i < 16 ; i++)
        {
            float x = -7.5f;
            for (int j = 0; j < 16; j++)
            {
                grid2[i,j] = new Vector3(x, y, -8.5f);
                x++;
            }
            y--;
        }
        //fata 3
        y = 15.5f;
        for (int i = 0; i < 16 ; i++)
        {
            float z = -7.5f;
            for (int j = 0; j < 16; j++)
            {
                grid3[i,j] = new Vector3(8.5f, y, z);
                z++;
            }
            y--;
        }
        //fata 4
        y = 15.5f;
        for (int i = 0; i < 16 ; i++)
        {
            float x = -7.5f;
            for (int j = 0; j < 16; j++)
            {
                grid4[i,j] = new Vector3(x, y, 8.5f);
                x++;
            }
            y--;
        }
        //fata 5
        float zz = 7.5f;
        for (int i = 0; i < 16 ; i++)
        {
            float xx = 7.5f;
            for (int j = 0; j < 16; j++)
            {
                grid5[i,j] = new Vector3(xx, 16.5f, zz);
                xx--;
            }
            zz--;
        }//fata 6
        zz = 7.5f;
        for (int i = 0; i < 16 ; i++)
        {
            float xx = 7.5f;
            for (int j = 0; j < 16; j++)
            {
                grid6[i,j] = new Vector3(xx, -0.5f, zz);
                xx--;
            }
            zz--;
        }
        SpawnFood();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnFood()
    {
        int randFace = Random.Range(1, 7);
        if (randFace == 1)
        {
            int randi = Random.Range(0, 16);
            int randj = Random.Range(0, 16);
            Instantiate(food, grid1[randi, randj], Quaternion.identity);
        }
        else if (randFace == 2)
        {
            int randi = Random.Range(0, 16);
            int randj = Random.Range(0, 16);
            Instantiate(food, grid2[randi, randj], Quaternion.identity);
        }
        else if (randFace == 3)
        {
            int randi = Random.Range(0, 16);
            int randj = Random.Range(0, 16);
            Instantiate(food, grid3[randi, randj], Quaternion.identity);
        }
        else if (randFace == 4)
        {
            int randi = Random.Range(0, 16);
            int randj = Random.Range(0, 16);
            Instantiate(food, grid4[randi, randj], Quaternion.identity);
        }
        else if (randFace == 5)
        {
            int randi = Random.Range(0, 16);
            int randj = Random.Range(0, 16);
            Instantiate(food, grid5[randi, randj], Quaternion.identity);
        }
        else
        {
            int randi = Random.Range(0, 16);
            int randj = Random.Range(0, 16);
            Instantiate(food, grid6[randi, randj], Quaternion.identity);
        }
    }
}
