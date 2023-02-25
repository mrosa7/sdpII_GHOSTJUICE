using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;


public class MASTERSCRIPT : MonoBehaviour
{
    public static MASTERSCRIPT Instance;
    public DialogManager DialogManager;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    //IDA INTERACTIONS (on click ghost sprite)
    #region  
    // INITIAL
    public void ida_interaction_1()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Who are you.", "Ida"));
        dialogTexts.Add(new DialogData("What do you want.", "Ida"));
        dialogTexts.Add(new DialogData("/color:red/Get out of my house.", "Ida"));

        DialogManager.Show(dialogTexts);
    }

    public void ida_interaction_2() // post puzzle 1 click
    {
        var dialogTexts2 = new List<DialogData>();
        dialogTexts2.Add(new DialogData("Stop messing around", "Ida"));
        dialogTexts2.Add(new DialogData("But...", "Ida"));
        dialogTexts2.Add(new DialogData("/size:down//size:down/Why was that picture ruined in the first place...", "Ida"));

        DialogManager.Show(dialogTexts2);
    }
    #endregion

    //Slide Puzzle Dialogue
    #region
    public void puzzle1_introduction()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("...What is this?", "Medium"));
        dialogTexts.Add(new DialogData("That's my mix tile paintings. I'd forgotten all about them. No use to me now..", "Ida"));
        dialogTexts.Add(new DialogData("...", "Medium"));
        DialogManager.Show(dialogTexts);
        dialogTexts.Add(new DialogData("/color:#B45ACF/Clicking on a tile that is adjacent to the empty space, will move the tile into the space.", "SYSTEM"));

    }

    public void postPuzzleDialogue_1()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("It's a picture of a ship."));
        dialogTexts.Add(new DialogData("Stop touching my things.", "Ida"));
        
        DialogManager.Show(dialogTexts);

    }
    #endregion

    //Item Interactions (passes through key word. Yes this is messy but if I had done this with public strings it would have been a MESS
    public void objInteraction(string keyWord)
    {
        if(keyWord == "ItemTest")
        {

            DialogData dialogData = new DialogData("I am an item. Edit my text in MasterScript.");
            DialogManager.Show(dialogData);
        }
    }
}
