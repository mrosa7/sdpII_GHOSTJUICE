using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTransition_obj : MonoBehaviour
{
    public GameObject[] objToHide;
    public GameObject[] ObjectToSwap;


    public void onClickSwap()
    {
        Invoke("swapRooms", 0.5f);
    }
    void swapRooms()
    {
        foreach (GameObject obj in objToHide)
        {
           
            obj.SetActive(false);
            
        }

        foreach (GameObject obj in ObjectToSwap)
        {
           
             obj.SetActive(true);
            
        }
    }
}
