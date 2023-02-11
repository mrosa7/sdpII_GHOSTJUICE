using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navigation : MonoBehaviour
{
    public GameObject currentRoom;
    public GameObject targetRoom;
    public GameObject navParent;
    public GameObject navTarget;

    public void OnCLick(GameObject currentRoom, GameObject targetRoom, GameObject navParent, GameObject navTarget)
    {
        //play animation fade in and out black
        //play foot steps
        currentRoom.SetActive(false);
        
        targetRoom.SetActive(true);
        navTarget.SetActive(true);

        navParent.SetActive(false);
    }
    
}
