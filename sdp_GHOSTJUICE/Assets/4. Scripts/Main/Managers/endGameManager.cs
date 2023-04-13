using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.SceneManagement;


public class endGameManager : MonoBehaviour
{
    public DialogManager DialogManager;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.State == GameState.EndGame && DialogManager.Overlay.activeSelf == false)
        {
            Invoke("triggerEnding", 5 );
        }
    }

    public void triggerEnding()
    {
        if (DialogManager.Overlay.activeSelf == false)
        {
            SceneManager.LoadScene(4);
        }



    }
}
