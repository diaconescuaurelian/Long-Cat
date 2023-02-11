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

    public void SpawnFood()//mai trebuie sa verifici sa nu se instantieze peste un obstacol sau peste un element de body
    {
        // mai trebuie sa verific daca sunt coliziuni inainte sa spawnez
        int randFace = Random.Range(1, 7);
        Vector3 position = Vector3.zero;
        switch (randFace)
        {
            case 1:
                int randi = Random.Range(0, 16);
                int randj = Random.Range(0, 16);
                position = grid1[randi, randj];
                break;
            case 2:
                randi = Random.Range(0, 16);
                randj = Random.Range(0, 16);
                position = grid2[randi, randj];
                break;
            case 3:
                randi = Random.Range(0, 16);
                randj = Random.Range(0, 16);
                position = grid3[randi, randj];
                break;
            case 4:
                randi = Random.Range(0, 16);
                randj = Random.Range(0, 16);
                position = grid4[randi, randj];
                break;
            case 5:
                randi = Random.Range(0, 16);
                randj = Random.Range(0, 16);
                position = grid5[randi, randj];
                break;
            case 6:
                randi = Random.Range(0, 16);
                randj = Random.Range(0, 16);
                position = grid6[randi, randj];
                break;
        }
        Collider[] colliders = Physics.OverlapSphere(position, 0.1f);
        while (colliders.Length > 0)
        {
            randFace = Random.Range(1, 7);
            switch (randFace)
            {
                case 1:
                    int randi = Random.Range(0, 16);
                    int randj = Random.Range(0, 16);
                    position = grid1[randi, randj];
                    break;
                case 2:
                    randi = Random.Range(0, 16);
                    randj = Random.Range(0, 16);
                    position = grid2[randi, randj];
                    break;
                case 3:
                    randi = Random.Range(0, 16);
                    randj = Random.Range(0, 16);
                    position = grid3[randi, randj];
                    break;
                case 4:
                    randi = Random.Range(0, 16);
                    randj = Random.Range(0, 16);
                    position = grid4[randi, randj];
                    break;
                case 5:
                    randi = Random.Range(0, 16);
                    randj = Random.Range(0, 16);
                    position = grid5[randi, randj];
                    break;
                case 6:
                    randi = Random.Range(0, 16);
                    randj = Random.Range(0, 16);
                    position = grid6[randi, randj];
                    break;
            }
            colliders = Physics.OverlapSphere(position, 0.1f);
        }
        switch (randFace)
        {
            case 1:
                Instantiate(food, position, Quaternion.identity);
                break;
            case 2:
                Instantiate(food, position, Quaternion.Euler(0, -90, 0));
                break;
            case 3:
                Instantiate(food, position, Quaternion.Euler(0, 180, 0));
                break;
            case 4:
                Instantiate(food, position, Quaternion.Euler(0, 90, 0));
                break;
            case 5:
                Instantiate(food, position, Quaternion.Euler(0, 0, -90));
                break;
            case 6:
                Instantiate(food, position, Quaternion.Euler(0, 0, 90));
                break;
        }
    }
}
