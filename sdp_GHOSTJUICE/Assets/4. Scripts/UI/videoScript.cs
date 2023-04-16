using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class videoScript : MonoBehaviour
{
    // Start is called before the first frame update
    VideoPlayer video;

    void Start()
    {
        //set up video to track
        video = GetComponent<VideoPlayer>();
        //video.Play();
        // StartCoroutine("WaitForMovieEnd");
        Invoke("videoEnded", 12);
    }


    /*public IEnumerator waitForVideoEnd()
    {
        while (video.isPlaying)
        {
            yield return new WaitForEndOfFrame();

        }
        videoEnded();
    }*/

    void videoEnded()
    {
        SceneManager.LoadScene(4);
    }
}

