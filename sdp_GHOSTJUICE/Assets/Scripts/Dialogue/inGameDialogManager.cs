using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class inGameDialogManager : MonoBehaviour
{
    public DialogManager dialogManager;
    //public GameObject[] textCalls;
    void Start()
    {
        //Plays this dialogue when the Player first enters the house.
        DialogData dialogData = new DialogData("You are now in the house. This is the inital message.");

        dialogManager.Show(dialogData);
    }

    // Hoenstly, I don't understand enums very well. But if you click on the ghost, it brings up dialogue based on the "state" that is based through.
    //State can be changed publicly. 
    //Change with Game Manager? 
    public void IdaInteraction(string State)
    {
        // when you click on Ida when player first walks in, after inital convo?
        if (State == "inital"){
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("Who are you.","Ida"));
            dialogTexts.Add(new DialogData("What do you want.", "Ida"));
            dialogTexts.Add(new DialogData("/color:red/Get out of my house.", "Ida"));

            dialogManager.Show(dialogTexts);
            //dialogTexts.Clear();
        }
    }
}
