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

    //substitute bools for event manager
    static bool fireBool;
    static bool hutBool;
    static bool fishBool;
    static bool waterBool;

    //Alpha version canvas to denote event happening 
    public GameObject forestCanvas;
    public GameObject stormCanvas;
    public GameObject rescueCanvas;

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
                break;
            default:
                break;
        }

        Debug.Log(waterBool);
        Debug.Log(fireBool);
        Debug.Log(hutBool);
        Debug.Log(fishBool);

        //player survives if they have all necessities 
        if (waterBool == true && fishBool == true && fireBool == true && hutBool == true)
            SceneManager.LoadScene(4);

    }

    // Update is called once per frame
    void Update()
    {
        //player dies if they go fishing while storm event is happening
        if (fishingScript.goneFishing == true && storm == true)
            SceneManager.LoadScene(2);
        else if (fishingScript.goneFishing == true)
        {
            fishBool = true;
            SceneManager.LoadScene(1);
        }

        //player dies if they go looking for water while forest event is happening
        if (bucketScript.bucketFilled == true && forest == true)
            SceneManager.LoadScene(2);
        else if (bucketScript.bucketFilled == true)
        {
            waterBool = true;
            SceneManager.LoadScene(1);
        }

        //if fire is lit and a tire is thrown in during the rescue event 
        if (fireBool == true && rescue == true && tireScript.tireOnFire == true)
            SceneManager.LoadScene(3);

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

        

        
    }
}
