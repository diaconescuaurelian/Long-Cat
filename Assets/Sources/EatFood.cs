using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatFood : MonoBehaviour
{
    
    GameObject food;
    GameObject foodSpawner;
    GameObject catBody;
    MoveCat catScript;
    public GameObject bodyPart;
    Grid gridScript;
    ChangeDirection lastBodyChangeDirection;
    ChangeDirection newBodyChangeDirection;
    Body bodyScript;
    Move moveScript;
    private int last;
    
    Transform curveRight;
    Transform curveLeft;
    Transform curveFace;
    Transform standard;
    Transform tail;
    // Start is called before the first frame update
    void Awake()
    {
        catBody = GameObject.FindGameObjectWithTag("LongCat");
        foodSpawner = GameObject.FindGameObjectWithTag("FoodSpawner");
        catScript = catBody.GetComponent<MoveCat>();
        gridScript = foodSpawner.GetComponent<Grid>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        food = GameObject.FindGameObjectWithTag("Food");
        ChangePrefab();
    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Food")
        {
            Destroy(food);
            gridScript.SpawnFood();
            last = catScript.cat.Count - 1;
            Vector3 position = catScript.cat[last].transform.position + catScript.cat[last].transform.up * -1;
            //instantiating a new body part 
            GameObject newBody = Instantiate(bodyPart, position, catScript.cat[last].transform.rotation) as GameObject;
            newBodyChangeDirection = newBody.GetComponent<ChangeDirection>();
            lastBodyChangeDirection = catScript.cat[last].GetComponent<ChangeDirection>();
            //setting its direction
            newBodyChangeDirection.setDirectionForNew(lastBodyChangeDirection);
            newBody.transform.parent = catBody.transform;
            bodyScript = newBody.GetComponent<Body>();
            moveScript = newBody.GetComponent<Move>();
            //setting its body type as body in its script components that will check for body type
            bodyScript.SetBodyType("body");
            newBodyChangeDirection.SetBodyType("body");
            catScript.cat.Add(newBody);
            //adding its script components to the coresponding lists
            catScript.AddNewScriptComponents(bodyScript, moveScript,newBodyChangeDirection);
            curveRight = catScript.cat[last].transform.Find("CatCurveRight");
            curveRight.gameObject.SetActive(false);
            curveLeft = catScript.cat[last].transform.Find("CatCurveLeft");
            curveLeft.gameObject.SetActive(false);
            curveFace = catScript.cat[last].transform.Find("CatCurveFace");
            curveFace.gameObject.SetActive(false);
            standard = catScript.cat[last].transform.Find("BodyPartStandard");
            standard.gameObject.SetActive(true);
            tail = catScript.cat[last].transform.Find("CatTail");
            tail.gameObject.SetActive(false);
        }
    }
    public void ChangePrefab()
    {
        int index = catScript.cat.Count - 1;
        curveRight = catScript.cat[index].transform.Find("CatCurveRight");
        curveRight.gameObject.SetActive(false);
        curveLeft = catScript.cat[index].transform.Find("CatCurveLeft");
        curveLeft.gameObject.SetActive(false);
        curveFace = catScript.cat[index].transform.Find("CatCurveFace");
        curveFace.gameObject.SetActive(false);
        standard = catScript.cat[index].transform.Find("BodyPartStandard");
        standard.gameObject.SetActive(false);
        tail = catScript.cat[index].transform.Find("CatTail");
        tail.gameObject.SetActive(true);
    }

    
}
