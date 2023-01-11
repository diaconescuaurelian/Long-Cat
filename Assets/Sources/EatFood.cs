using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    GameObject food;
    GameObject food_spawner;
    GameObject cat_body;
    Cat cat_script;
    public GameObject body_part;
    // Start is called before the first frame update
    void Awake()
    {
        cat_body = GameObject.FindGameObjectWithTag("LongCat");
        food_spawner = GameObject.FindGameObjectWithTag("FoodSpawner");
        cat_script = GetComponent<Cat>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        food = GameObject.FindGameObjectWithTag("Food");
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Destroy(food);
            food_spawner.GetComponent<Grid>().SpawnFood();
            int last = cat_body.GetComponent<Cat>().cat.Count - 1;
            Vector3 position = cat_body.GetComponent<Cat>().cat[last].transform.position + cat_body.GetComponent<Cat>().cat[last].transform.up * cat_body.GetComponent<Cat>().distance;
            GameObject new_body = Instantiate(body_part, position, cat_body.GetComponent<Cat>().cat[last].transform.rotation) as GameObject;
            cat_body.GetComponent<Cat>().cat.Add(new_body);
            

            
        }
    }
}
