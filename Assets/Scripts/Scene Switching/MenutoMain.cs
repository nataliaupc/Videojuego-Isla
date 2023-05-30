using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenutoMain : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(2);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}

