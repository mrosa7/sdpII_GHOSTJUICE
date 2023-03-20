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
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Well, time to get down to business.", "Medium"));
        dialogTexts.Add(new DialogData("Hello? I’m here to speak to Miss Ida Wagner.", "Medium"));
        dialogTexts.Add(new DialogData("…Ida, I have reason to believe that you’re here with me right now.", "Medium"));
        // trigger sound effect
        dialogTexts.Add(new DialogData(" If you are, please give me a sign.", "Medium"));
        // trigger music
        dialogTexts.Add(new DialogData("(Good, we’re getting somewhere.)", "Medium"));
        dialogTexts.Add(new DialogData("Alright, Miss Wagner, thank you for your cooperation. Now, if I can, I would like to ask a couple of questions. ", "Medium"));
        dialogTexts.Add(new DialogData("I’m working with the police, my name is Inspector--", "Medium"));
        //trigger sound effect
        dialogTexts.Add(new DialogData("Hey now, no need to get all freaked out, I just wanted to- ", "Medium"));
        //another sound effect
        dialogTexts.Add(new DialogData("Okay, look- you know this isn’t scaring me, right?", "Medium"));
        dialogTexts.Add(new DialogData("I know that you’re here, and you know I’M here, and I’m not leaving until I get some answers- ", "Medium"));
        dialogTexts.Add(new DialogData("Now show yourself right now!", "Medium"));
        // pause things, add thunderclap, IDA appears. 
        dialogTexts.Add(new DialogData("So, you’re one of them coppers, huh?", "Ida"));
        dialogTexts.Add(new DialogData("Who sent you?! Where’s your warrant?! I bet one of those punks who broke in ratted me out to you, didn’t they?!", "Ida"));
        dialogTexts.Add(new DialogData("First they try and swipe some of my booze and then they snitch on me when they can’t get it, honestly I OUGHTA-", "Ida"));
        dialogTexts.Add(new DialogData("Okay, okay, SLOW DOWN, ma’am.", "Medium"));
        dialogTexts.Add(new DialogData("I know this is all a bit of a surprise to you, just give me a second to explain.", "Medium"));
        dialogTexts.Add(new DialogData("...", "Ida"));
        dialogTexts.Add(new DialogData("You can see me. You can actually see me.", "Ida"));
        dialogTexts.Add(new DialogData("And I can hear you.", "Medium"));
        dialogTexts.Add(new DialogData("And you’re not running away screaming either.", "Ida"));
        dialogTexts.Add(new DialogData("I’ve been in this business for a while now. This kinda stuff rarely fazes me anymore. Anyways- if I’m not mistaken, you must be Ida Wagner, Correct?", "Medium"));
        dialogTexts.Add(new DialogData("In the flesh- or well, you know what I mean.", "Ida"));
        dialogTexts.Add(new DialogData("Look, this doesn’t change the fact that you’re on private property- lemme ask again.", "Ida"));
        dialogTexts.Add(new DialogData("Who sent you?", "Ida"));
        dialogTexts.Add(new DialogData("Well, as established, I am working with the police, but you’re not in any trouble. At least, not in the way you think.", "Medium"));
        dialogTexts.Add(new DialogData("Let’s start with the obvious- you, Miss Wagner, are dead. I would think that you are aware of this. ", "Medium"));
        dialogTexts.Add(new DialogData("…You could say that.", "Ida"));
        dialogTexts.Add(new DialogData("And since you’re obviously not 'resting in peace', there must be some reason why you find yourself unable to move on from this place, correct ?", "Medium"));
        dialogTexts.Add(new DialogData("No dip, Sherlock, what do you think?!", "Ida"));
        dialogTexts.Add(new DialogData("I’ve been stuck here for who knows how long, floating around with my memories all in a haze…every time I try to go back to the day I bit the big one, my mind just… clouds over. ", "Ida"));
        dialogTexts.Add(new DialogData("Everything’s clouded over,", "Ida"));
        dialogTexts.Add(new DialogData("And not having a body’s even worse- I forgot what it feels like to-well, feel anything.", "Ida"));
        dialogTexts.Add(new DialogData("At this point, I don’t even feel like a person anymore.", "Ida"));
        dialogTexts.Add(new DialogData("And now…now I got everyone snooping around here uninvited, walking in like they own the place!", "Ida"));
        dialogTexts.Add(new DialogData("It’s enough to drive someone mad!", "Ida"));
        dialogTexts.Add(new DialogData("I see.", "Medium"));
        dialogTexts.Add(new DialogData("…I’m sorry for being a bit too blunt, but like you said, it’s a wonder I can communicate directly with you, and because of that, I want to help you.", "Ida"));
        dialogTexts.Add(new DialogData("Huh?", "Ida"));
        dialogTexts.Add(new DialogData("There’s reason to believe that there’s more to your disappearance than meets the eye.", "Medium"));
        dialogTexts.Add(new DialogData("Sure, the case doesn’t really have a leg to stand on, but you being here right now confirms that you did die here- we just don’t know anything else aside from that.", "Medium"));
        dialogTexts.Add(new DialogData("Please, I know you’re just as in the dark as us right now, but just let me conduct my investigation and maybe we can find out together.", "Medium"));
        dialogTexts.Add(new DialogData("You can finally escape this cycle of pain you’ve found yourself in for the past 70 years.", "Medium"));
        dialogTexts.Add(new DialogData("Please. Just give me a chance.", "Medium"));
        dialogTexts.Add(new DialogData("… You drive a hard bargain.", "Ida"));
        dialogTexts.Add(new DialogData("Fine, I’ll let you take a look around, but first, I'd like you to do something for me.", "Ida"));
        dialogTexts.Add(new DialogData(" Be a dear and light the fireplace, will ya?", "Ida"));
        dialogTexts.Add(new DialogData("You’ll need matches and some tinder to get the fire going- they’re all hiding around here somewhere", "Ida"));
        dialogTexts.Add(new DialogData("Now get on with it, and no funny business, alright?", "Ida"));
        dialogTexts.Add(new DialogData("Remember, I’m watching you.", "Ida"));
        DialogManager.Show(dialogTexts);
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
            dialogTexts.Add(new DialogData("...", "Ida"));
            //dialogTexts.Add(new DialogData("What do you want.", "Ida"));
            //dialogTexts.Add(new DialogData("/color:red/Get out of my house.", "Ida"));

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

    // Clock Puzzle DIalogue
    #region
    public void postPuzzleDialogue_2()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("... I can't read analog clocks.", "Medium"));
        dialogTexts.Add(new DialogData("...It's 5:45.", "Ida"));

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
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("Hey, hey, I thought you weren’t here for that!", "Ida"));
            dialogTexts.Add(new DialogData("(Sigh)", "Medium"));
            dialogTexts.Add(new DialogData("Sorry. I forgot you guys didn’t exactly have the privilege of cracking open a cold one out in the open back then.", "Medium"));
            dialogTexts.Add(new DialogData("Say, where’d you get this stuff anyways?", "Medium"));
            dialogTexts.Add(new DialogData("....", "Ida"));
            dialogTexts.Add(new DialogData("I swear this info is needed for the investigation.", "Medium"));
            dialogTexts.Add(new DialogData("... (Sigh)", "Ida"));
            dialogTexts.Add(new DialogData("How do I even begin to describe him?", "Ida"));
            dialogTexts.Add(new DialogData("Him? ", "Medium"));
            dialogTexts.Add(new DialogData("His name was Raymond Hyde. Real shady guy, never liked him all that much. ", "Ida"));
            dialogTexts.Add(new DialogData("Still, he was… in my circle, whether I liked it or not.", "Ida"));
            dialogTexts.Add(new DialogData("At first, I didn’t want to do business with him, but in the end, he made an offer I couldn’t refuse. ", "Ida"));
            dialogTexts.Add(new DialogData("After all, it ain’t New Year’s without some good drinks, and I couldn’t let my guests go thirsty.", "Ida"));
            dialogTexts.Add(new DialogData("Even if I had to get my bootleg from him, of all people.", "Ida"));
            dialogTexts.Add(new DialogData("Hm. I’ll keep that in mind.", "Medium"));
            dialogTexts.Add(new DialogData("(Hey, there seems to be something stuck underneath one of the bottles.)", "Medium"));
            dialogTexts.Add(new DialogData("(Hm. It’s a paper party invitation. Maybe I can use this for the fire.)", "Medium"));
            dialogTexts.Add(new DialogData("[Found: Party Invite]", "SYSTEM"));
            dialogTexts.Add(new DialogData("Hey Miss Wagner, you wouldn’t mind if I used this to get the fire going, would you?", "Medium"));
            dialogTexts.Add(new DialogData("It’s not like anyone else needs them right now. ", "Medium"));
            dialogTexts.Add(new DialogData("…I suppose. You’re gonna need more than just one, though.", "Ida"));

            DialogManager.Show(dialogTexts);
        }

        else if (keyWord == "Chandelier")
        {
            DialogData dialogData = new DialogData("An old chandelier... hope it doesn't fall.", "Medium");
            DialogManager.Show(dialogData);
        }

        else if (keyWord == "Wallpaper")
        {
            DialogData dialogData = new DialogData("This place is really falling apart...", "Medium");
            DialogManager.Show(dialogData);
        }
        else if (keyWord == "Gramophone")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("(It’s weird that this thing still works after all this time…)", "Medium"));
            dialogTexts.Add(new DialogData("It was always one of my go-tos at the club where I used to work. I even started the party with my rendition of it.", "Ida"));
            dialogTexts.Add(new DialogData("It’s funny… I had this whole shindig to really put myself out there, you know?", "Ida"));
            dialogTexts.Add(new DialogData("Maybe I could rub elbows with some big shots, make some connections, nab a major gig, and really become a star… ", "Ida"));
            dialogTexts.Add(new DialogData("I didn’t even make it to midnight.", "Ida"));
            dialogTexts.Add(new DialogData("… Miss Wagner?", "Medium"));
            dialogTexts.Add(new DialogData("…Wait, you didn’t hear all that, didn’t you?", "Ida"));
            dialogTexts.Add(new DialogData("J-just forget I said anything. Hey look,  something you should pay more attention to!", "Ida"));
            dialogTexts.Add(new DialogData("(She’s right, there’s something stuffed inside the bell of the gramophone.)", "Ida"));
            dialogTexts.Add(new DialogData("[Found: Paper Invite].", "SYSTEM"));
            DialogManager.Show(dialogTexts);
        }
        else if(keyWord == "Chest")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("(Hey, there seems to be something in here.)", "Medium"));
            dialogTexts.Add(new DialogData("[Found: Box of Matches].", "SYSTEM"));
        }
    }

    #endregion
}
