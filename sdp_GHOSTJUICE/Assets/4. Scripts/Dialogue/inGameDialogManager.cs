using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.EventSystems;


public class inGameDialogManager : MonoBehaviour
{
    //public string GhostState;
    public DialogManager dialogManager;

    bool puzzle1_tutorial = true;

    void Start()
    {
        //Plays this dialogue when the Player first enters the house.
        DialogData dialogData = new DialogData("You are now in the house. This is the inital message.");

        dialogManager.Show(dialogData);
            //GhostState = "inital";
    }

/*    // Hoenstly, I don't understand enums very well. But if you click on the ghost, it brings up dialogue based on the "state" that is based through.
    //State can be changed publicly. 
    //Change with Game Manager? 
    public void IdaInteraction(string State)
    {
        // when you click on Ida when player first walks in, after inital convo?
        if (State == "inital"){

            MASTERSCRIPT.Instance.ida_interaction_1();
        }
        
        if(State == "postPuzzle1")
        {
            MASTERSCRIPT.Instance.ida_interaction_2();
        }
    }*/

    public void puzzle1_intro()
    {
        if (puzzle1_tutorial)
        {
            MASTERSCRIPT.Instance.puzzle1_introduction();
            puzzle1_tutorial = false;
        }
    }



    // Start is called before the first frame update

 /*   public void OnPointerClick(PointerEventData eventData)
    {

        Debug.Log("IM BEING CLICKED");
        IdaInteraction(GhostState);
    }*/

}
