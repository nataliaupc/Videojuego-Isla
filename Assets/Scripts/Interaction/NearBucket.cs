using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NearBucket : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    public bool bucketFilled = false;
    public GameObject text;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
            text.SetActive(true);
            //print("Collision detected");
            if (Input.GetKeyDown(KeyCode.E))
            {
                bucketFilled = true;
                SceneManager.LoadScene(2);
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = false;
            text.SetActive(false);
        }
    }
}
