using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class endGameManager : MonoBehaviour
{
    public DialogManager DialogManager;
    public GameObject blackScreenObj;
    Animation ani;
    Image blackScreen;

    // Start is called before the first frame update
    void Start()
    {
        ani = blackScreenObj.GetComponent<Animation>();
        blackScreen = blackScreenObj.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State == GameState.EndGame && DialogManager.Overlay.activeSelf == false)
        {
            Invoke("cueAni", 5);
            //Invoke("triggerEnding", 6.5f );
        }
    }

    public void triggerEnding()
    {
        if (DialogManager.Overlay.activeSelf == false)
        {
            SceneManager.LoadScene(3);
        }



    }

    public void cueAni()
    {
        if (DialogManager.Overlay.activeSelf == false)
        {
            blackScreen.enabled = true;
            ani.Play("toBlack");
            Invoke("triggerEnding", 2);
        }
    }
}
