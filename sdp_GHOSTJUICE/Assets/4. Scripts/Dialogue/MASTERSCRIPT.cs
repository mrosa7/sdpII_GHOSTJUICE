using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

// EXPAND REGION TO VIEW CODE
public class MASTERSCRIPT : MonoBehaviour
{
    public static MASTERSCRIPT Instance;
    public DialogManager DialogManager;


    bool puzzle1_tutorial = true;
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
          //Plays this dialogue when the Player first enters the house.
        DialogData dialogData = new DialogData("Let's have a look around.", "Medium");

        DialogManager.Show(dialogData);
        //GhostState = "inital";
    }

    //IDA INTERACTIONS (on click ghost sprite)
    #region  
    // bro i need to find a better way to store this. I could use another round of enums ;-;-; 

    public void Ida_Interaction(GameState state, string room)
    {
        // interaction in living room, pre puzzle 1
        if (GameState.StartGame == GameManager.Instance.State && room == "foyer"){
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("Who are you.", "Ida"));
            dialogTexts.Add(new DialogData("What do you want.", "Ida"));
            dialogTexts.Add(new DialogData("/color:red/Get out of my house.", "Ida"));

            DialogManager.Show(dialogTexts);
        }
        else if (GameState.FirstPuzzleComplete == GameManager.Instance.State && room == "foyer")
        {
            var dialogTexts2 = new List<DialogData>();
            dialogTexts2.Add(new DialogData("Stop messing around", "Ida"));
            dialogTexts2.Add(new DialogData("But...", "Ida"));
            dialogTexts2.Add(new DialogData("/size:down//size:down/Why was that picture ruined in the first place...", "Ida"));

            DialogManager.Show(dialogTexts2);
        }

        else if (GameState.StartGame == GameManager.Instance.State && room == "livingRoom")
        {
            var dialogTexts2 = new List<DialogData>();
            dialogTexts2.Add(new DialogData("Hello MTV and welcome to my crib.", "Ida"));
            DialogManager.Show(dialogTexts2);
        }

        else if (GameState.FirstPuzzleComplete == GameManager.Instance.State && room == "livingRoom")
        {
            var dialogTexts2 = new List<DialogData>();
            dialogTexts2.Add(new DialogData("....", "Ida"));
            dialogTexts2.Add(new DialogData("Imagine if this puzzle was timed.", "Ida"));
            dialogTexts2.Add(new DialogData("lololololol.", "Ida"));
            DialogManager.Show(dialogTexts2);
        }
    }

    //Scrap?
    /*public void ida_interaction_1()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Who are you.", "Ida"));
        dialogTexts.Add(new DialogData("What do you want.", "Ida"));
        dialogTexts.Add(new DialogData("/color:red/Get out of my house.", "Ida"));

        DialogManager.Show(dialogTexts);
    }
*/
    /*public void ida_interaction_2() // post puzzle 1 click
    {
        var dialogTexts2 = new List<DialogData>();
        dialogTexts2.Add(new DialogData("Stop messing around", "Ida"));
        dialogTexts2.Add(new DialogData("But...", "Ida"));
        dialogTexts2.Add(new DialogData("/size:down//size:down/Why was that picture ruined in the first place...", "Ida"));

        DialogManager.Show(dialogTexts2);
    }*/
    #endregion

    //Slide Puzzle Dialogue
    #region
    public void puzzle1_introduction()
    {
        if (puzzle1_tutorial)
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("...What is this?", "Medium"));
            dialogTexts.Add(new DialogData("That's my mix tile paintings. I'd forgotten all about them. No use to me now..", "Ida"));
            dialogTexts.Add(new DialogData("...", "Medium"));

            dialogTexts.Add(new DialogData("/color:#B45ACF/Clicking on a tile that is adjacent to the empty space, will move the tile into the space.", "SYSTEM"));
            DialogManager.Show(dialogTexts);
            puzzle1_tutorial = false;
        }
    }

    public void postPuzzleDialogue_1()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("It's a picture of a ship."));
        dialogTexts.Add(new DialogData("Stop touching my things.", "Ida"));
        
        DialogManager.Show(dialogTexts);

    }
    #endregion

    //OBJECT INTERACTION LINES
    #region
    //Item Interactions (passes through key word. Yes this is messy but if I had done this with public strings it would have been a MESS
    public void objInteraction(string keyWord)
    {
        if (keyWord == "ItemTest")
        {

            DialogData dialogData = new DialogData("I am an item. Edit my text in MasterScript.");
            DialogManager.Show(dialogData);
        }


        else if (keyWord == "bottle")
        {
            DialogData dialogData = new DialogData("A old broken bottle. I wonder how many people have been here.", "Medium");
            DialogManager.Show(dialogData);
        }

        else if (keyWord == "Chandelier")
        {
            DialogData dialogData = new DialogData("An old chandelier... hope it doesn't fall.", "Medium");
            DialogManager.Show(dialogData);
        }
    }

    #endregion
}
