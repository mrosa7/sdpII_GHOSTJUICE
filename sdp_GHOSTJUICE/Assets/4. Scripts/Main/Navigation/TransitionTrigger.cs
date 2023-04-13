using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionTrigger : MonoBehaviour
{
    Animation ani;
    Image blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animation>();
        blackScreen = gameObject.GetComponent<Image>();
        //ani.enabled = false;
    }

   public void ChangeRoom()
    {
        blackScreen.enabled = true;
        ani.Play("TransitionBlack");
        Invoke("turnOff", 1.1f);
        
    }

    void turnOff()
    {
        blackScreen.enabled = false;
    }


}
