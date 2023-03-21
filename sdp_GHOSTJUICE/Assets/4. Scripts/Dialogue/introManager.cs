using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class introManager : MonoBehaviour
{
    public Button backbutton;
    public GameObject forwardbutton;
    public GameObject continuebutton;
    [SerializeField] private List<GameObject> Pages;

    GameObject currentPage;
    int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        backbutton.interactable = false;
        continuebutton.SetActive(false);
        currentPage = Pages[0];
    }

    public void indexForward()
    {
        //Triiger Animation
        if (currentPage != Pages[2])
        {
            
            currentPage.GetComponent<Animation>().Play("page0_exit");
            index += 1;
            currentPage = Pages[index];
            if (index == 2)
            {
                forwardbutton.SetActive(false);
                continuebutton.SetActive(true);
                backbutton.interactable = true;
            }
            else
            {
                forwardbutton.SetActive(true);
                continuebutton.SetActive(false);
                backbutton.interactable = true;
            }
        }
        Debug.Log(currentPage.name);
    }

    public void indexBack()
    {
        //Triiger Animation
        if (currentPage != Pages[0])
        {
            
            index -= 1;
            //trigger current page enter animation
            
            currentPage = Pages[index];
            currentPage.GetComponent<Animation>().Play("page0_enter");
            if (index == 0)
            {
                forwardbutton.SetActive(true);
                continuebutton.SetActive(false);
                backbutton.interactable = false;
            }
            else
            {
                forwardbutton.SetActive(true);
                continuebutton.SetActive(false);
            }
        }
        Debug.Log(currentPage.name);
    }
 
    // Update is called once per frame
    void Update()
    {
        
    }
}
