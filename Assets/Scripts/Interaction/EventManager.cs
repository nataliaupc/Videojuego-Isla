using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EventManager : MonoBehaviour
{
    //world events
    public int events;
    public bool nothing;
    public bool storm;
    public bool forest;
    public bool rescue;
    public bool hunt;
    
    //objects related to the bonefire interaction
    public NearFire fireScript;
    public GameObject fireCollider;
    private GameObject Fire;

    //objects related to the fishing interaction
    public NearBoat fishingScript;
    public GameObject boatCollider;
    private GameObject Boat;

    //objects related to the bucket interaction
    public NearConstruction constructionScript;
    public GameObject constructionCollider;
    private GameObject Bucket;

    //objects related to the construction interaction
    public NearBucket bucketScript;
    public GameObject bucketCollider;
    private GameObject Hut;

    //objects related to the tire interaction
    public NearTires tireScript;
    public GameObject tireCollider;
    private GameObject tires;

    //objects related to hunting
    public NearWeapons huntScript;
    public GameObject weaponsCollider;
    private GameObject weapons;

    //substitute bools for event manager
    static bool fireBool = false;
    static bool hutBool = false;
    static bool fishBool = false;
    static bool waterBool = false;
    static bool weaponBool = false;

    //Alpha version canvas to denote event happening 
    public GameObject forestCanvas;
    public GameObject stormCanvas;
    public GameObject rescueCanvas;

    //Alpha version canvas to denote interaction done by player 
    public GameObject fireCanvas;
    public GameObject waterCanvas;
    public GameObject hutCanvas;
    public GameObject fishCanvas;
    public GameObject weaponCanvas;

    //Objects related to events 
    public GameObject forestEvent;
    public GameObject stormEvent;
    public GameObject rescueEvent;

    //Objects related to choices
    public GameObject fireChoice;
    public GameObject waterChoice;
    public GameObject hutChoice;
    public GameObject hutMats;
    public GameObject fishChoice;
    public GameObject weaponChoice;

    // Start is called before the first frame update
    void Start()
    {

        events = Random.Range( 0, 4);
        
        //deactivate interaction colliders in case an option has been chosen (next cicle it wont show) but not for repeatable actions
        //later we will implement ways/events which will change the state of each defining bool so as to add variability

        //check if fire lit to deactivate collider 
        if (fireScript.fireLit == true)
            fireCollider.SetActive(false);
        else
            fireCollider.SetActive(true);

        //check if built hut to deactivate collider 
        if (constructionScript.hutBuilt == true)
            constructionCollider.SetActive(false);
        else
            constructionCollider.SetActive(true);

        switch(events)
        {
            case 0:
                nothing = true;
                Debug.Log("Nothing event");
                break;
            case 1:
                storm = true;
                Debug.Log("Storm event");
                stormCanvas.SetActive(true);
                break;
            case 2:
                forest = true;
                Debug.Log("forest event");
                forestCanvas.SetActive(true);
                break;
            case 3:
                rescue = true;
                Debug.Log("rescue event");
                rescueCanvas.SetActive(true);
                rescueEvent.SetActive(true);
                break;
            default:
                break;
        }

        Debug.Log(waterBool);
        Debug.Log(fireBool);
        Debug.Log(hutBool);
        Debug.Log(fishBool);
        Debug.Log(weaponBool);

        //player survives if they have all necessities 
        if (waterBool == true && fishBool == true && fireBool == true && hutBool == true)
        {
            waterBool = false;
            fishBool = false;
            fireBool = false;
            hutBool = false;
            weaponBool = false;
            SceneManager.LoadScene(4);
        }

        //commented canvases are QOL text on screen to let player know what they had interacted with in alpha
        if (waterBool == true)
            waterChoice.SetActive(true);
        //waterCanvas.SetActive(true);

        if (fishBool == true)
            fishChoice.SetActive(true);
        //fishCanvas.SetActive(true);

        if(fireBool == true)
            fireChoice.SetActive(true);
        //fireCanvas.SetActive(true);


        if (hutBool == true)
        {
            hutChoice.SetActive(true);
            hutMats.SetActive(false);
            //hutCanvas.SetActive(true);
        }

        if (weaponBool == true)
            weaponCanvas.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        //player dies if they go fishing while storm event is happening
        if (fishingScript.goneFishing == true && storm == true)
        {
            waterBool = false;
            fishBool = false;
            fireBool = false;
            hutBool = false;
            weaponBool = false;
            SceneManager.LoadScene(2);
        }
        else if (fishingScript.goneFishing == true)
        {
            fishBool = true;
            SceneManager.LoadScene(1);
        }

        //player dies if they go looking for water while forest event is happening
        if (bucketScript.bucketFilled == true && forest == true)
        {
            waterBool = false;
            fishBool = false;
            fireBool = false;
            hutBool = false;
            weaponBool = false;
            SceneManager.LoadScene(2);
        }
        else if (bucketScript.bucketFilled == true)
        {
            waterBool = true;
            SceneManager.LoadScene(1);
        }

        //player dies if they go hunting while forest event is happening
        if (huntScript.goneHunting == true && forest == true)
        {
            waterBool = false;
            fishBool = false;
            fireBool = false;
            hutBool = false;
            weaponBool = false;
            SceneManager.LoadScene(2);
        }
        else if (huntScript.goneHunting == true)
        {
            weaponBool = true;
            SceneManager.LoadScene(1);
        }

        //if fire is lit and a tire is thrown in during the rescue event 
        if (fireBool == true && rescue == true && tireScript.tireOnFire == true)
        {
            waterBool = false;
            fishBool = false;
            fireBool = false;
            hutBool = false;
            weaponBool = false;
            SceneManager.LoadScene(3);
        }

        //other actions which have no interaction as of alpha
        if (fireScript.fireLit == true)
        {
            fireBool = true;
            SceneManager.LoadScene(1);
        }

        if (constructionScript.hutBuilt == true)
        {
            hutBool = true;
            SceneManager.LoadScene(1);
        }


        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }
}
