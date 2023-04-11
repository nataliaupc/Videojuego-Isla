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
                break;
            case 2:
                forest = true;
                Debug.Log("forest event");
                break;
            case 3:
                rescue = true;
                Debug.Log("rescue event");
                break;
            default:
                break;
        }

        //player dies if they go fishing while storm event is happening
        if (fishingScript.goneFishing == true && storm == true)
            SceneManager.LoadScene(3);

        //player dies if they go looking for water while forest event is happening
        if (bucketScript.bucketFilled == true && forest == true)
            SceneManager.LoadScene(3);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
