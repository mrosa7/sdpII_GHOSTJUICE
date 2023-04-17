using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doNotDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("endAudio"))
        {
            GameObject audioSourceObj = GameObject.FindGameObjectWithTag("endAudio");
            DontDestroyOnLoad(audioSourceObj);
        }

        // Update is called once per frame
    }

}
