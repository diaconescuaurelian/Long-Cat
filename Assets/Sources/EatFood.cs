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
        }
    }
    //se mai intampla uneori sa se strice sarpele
    //nu se strica decat la ultimul element ceea ce ma face sa cred ca trebuie sa se seteze orientarea gresit
    //imi vin in minte doua modalitati sa repar asta.
    //1 sa verific daca e instantiat pe un collider
    //2 cand refac modul in care se schimba un body pe o alta fata sa tin cont si daca un element e nou instantiat
    //sau sa fac astfel incat ultimul element sa primeasca automat rotatia elementului din fata lui
    //Sigur 100% nu e de la mutat aiurea cand head-ul isi schimba directia. Cel mai Probabil are legatura cu faptul ca nu ia corect rotatia elementului din fata lui.
    //Mai intai o sa incerc noua metoda de schimbare pe o alta fata, dupa care o sa verific daca se mai intampla.
    //daca se intampla in continuareo sa fac ca daca penultimul element se roteste pe o alta fata, sa se roteasca si ultimul, care la momentul ala ar fi pe collider.

    
}
