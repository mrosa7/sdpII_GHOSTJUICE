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
    
    public void postPuzzleDialogue_1()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("It's a picture of a ship", "Ida"));
        dialogTexts.Add(new DialogData("Stop touching my things.", "Ida"));
        
        DialogManager.Show(dialogTexts);

    }

}
