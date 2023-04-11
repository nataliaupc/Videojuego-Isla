using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NearTires : MonoBehaviour
{
    [SerializeField] private bool triggerActive = false;
    public bool tireOnFire = false;
    public GameObject text;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerActive = true;
            text.SetActive(true);
            //print("Collision detected");
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

    public void Update()
    {
        if (triggerActive == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                tireOnFire = true;
                //SceneManager.LoadScene(0);
                Debug.Log("Pressing select button");
            }
        }
    }
}
