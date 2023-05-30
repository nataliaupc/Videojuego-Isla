using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoScriptEnd : MonoBehaviour
{
    VideoPlayer video;
    //public GameObject canvas;
    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;


    }

    private void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene(1);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        SceneManager.LoadScene(1);//the scene that you want to load after the video has ended.
        //canvas.SetActive(false);
    }
}
