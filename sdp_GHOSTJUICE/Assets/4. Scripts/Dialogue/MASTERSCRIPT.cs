using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;
using UnityEngine.SceneManagement;

// EXPAND REGION TO VIEW CODE
public class MASTERSCRIPT : MonoBehaviour
{
    public static MASTERSCRIPT Instance;
    public DialogManager DialogManager;


    bool puzzle1_tutorial = true;
    bool puzzle2_intro = true;
    bool upstairsIntro = true;
    bool bedroomIntro = true;
    bool atticIntro = true;
    public GameObject endGameManager;
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
        dialogTexts.Add(new DialogData("Hello? I'm here to speak to Miss Ida Wagner.", "Medium"));
        dialogTexts.Add(new DialogData("...", "Medium"));
        dialogTexts.Add(new DialogData("...Ida, I have reason to believe that you're here with me right now.", "Medium"));
        dialogTexts.Add(new DialogData(" If you are, please give me a sign.", "Medium"));
        dialogTexts.Add(new DialogData("....", "Medium"));
        dialogTexts.Add(new DialogData("/sound:Footsteps/!!!", "Medium")); // <Knock, footsteps, ghost noise?>
        dialogTexts.Add(new DialogData("(Good, we're getting somewhere.)", "Medium"));
        dialogTexts.Add(new DialogData("Alright, Miss Wagner, thank you for your cooperation. Now, if I can, I would like to ask a couple of questions. ", "Medium"));
        dialogTexts.Add(new DialogData("I'm working with the police, my name is Inspector--", "Medium"));
        dialogTexts.Add(new DialogData("/sound:GhostNoise/!!!??", "Medium")); // < angry ghost noise / agressive>
                                                                              //trigger sound effect
        dialogTexts.Add(new DialogData("Hey now, no need to get all freaked out, I just wanted to- ", "Medium"));
        //another sound effect
        dialogTexts.Add(new DialogData("(CRASH)", "Ida")); // <Ida throws something>
        dialogTexts.Add(new DialogData("Okay, look- you know this isn't scaring me, right?", "Medium"));
        dialogTexts.Add(new DialogData("I know that you're here, and you know I'M here, and I'm not leaving until I get some answers- ", "Medium"));
        dialogTexts.Add(new DialogData("Now show yourself right now!", "Medium"));
        // pause things, add thunderclap, IDA appears. 
        dialogTexts.Add(new DialogData("...", "Medium"));
        dialogTexts.Add(new DialogData("/sound:Thunderclap/......", "Medium")); // <thunderclap>
        dialogTexts.Add(new DialogData("...", "Ida"));
        dialogTexts.Add(new DialogData("So, you're one of them coppers, huh?", "Ida"));
        dialogTexts.Add(new DialogData("Who sent you?! Where's your warrant?! I bet one of those punks who broke in ratted me out to you, didn't they?!", "Ida"));
        dialogTexts.Add(new DialogData("First they try and swipe some of my booze and then they snitch on me when they can't get it, honestly I OUGHTA-", "Ida"));
        dialogTexts.Add(new DialogData("Okay, okay, SLOW DOWN, ma'am.", "Medium"));
        dialogTexts.Add(new DialogData("I know this is all a bit of a surprise to you, just give me a second to explain.", "Medium"));
        dialogTexts.Add(new DialogData("...", "Ida"));
        dialogTexts.Add(new DialogData("You can see me. You can actually see me.", "Ida"));
        dialogTexts.Add(new DialogData("And I can hear you.", "Medium"));
        dialogTexts.Add(new DialogData("And you're not running away screaming either.", "Ida"));
        dialogTexts.Add(new DialogData("I've been in this business for a while now. This kinda stuff rarely fazes me anymore. Anyways- if I'm not mistaken, you must be Ida Wagner, Correct?", "Medium"));
        dialogTexts.Add(new DialogData("In the flesh- or well, you know what I mean.", "Ida"));
        dialogTexts.Add(new DialogData("Look, this doesn't change the fact that you're on private property- lemme ask again.", "Ida"));
        dialogTexts.Add(new DialogData("Who sent you?", "Ida"));
        dialogTexts.Add(new DialogData("Well, as established, I am working with the police, but you're not in any trouble. At least, not in the way you think.", "Medium"));
        dialogTexts.Add(new DialogData("Let's start with the obvious- you, Miss Wagner, are dead. I would think that you are aware of this. ", "Medium"));
        dialogTexts.Add(new DialogData("...You could say that.", "Ida"));
        dialogTexts.Add(new DialogData("And since you're obviously not 'resting in peace', there must be some reason why you find yourself unable to move on from this place, correct ?", "Medium"));
        dialogTexts.Add(new DialogData("No dip, Sherlock, what do you think?!", "Ida"));
        dialogTexts.Add(new DialogData("I've been stuck here for who knows how long, floating around with my memories all in a haze...every time I try to go back to the day I bit the big one, my mind just... clouds over. ", "Ida"));
        dialogTexts.Add(new DialogData("Everything's clouded over,", "Ida"));
        dialogTexts.Add(new DialogData("And not having a body's even worse- I forgot what it feels like to-well, feel anything.", "Ida"));
        dialogTexts.Add(new DialogData("At this point, I don't even feel like a person anymore.", "Ida"));
        dialogTexts.Add(new DialogData("And now...now I got everyone snooping around here uninvited, walking in like they own the place!", "Ida"));
        dialogTexts.Add(new DialogData("It's enough to drive someone mad!", "Ida"));
        dialogTexts.Add(new DialogData("I see.", "Medium"));
        dialogTexts.Add(new DialogData("...I'm sorry for being a bit too blunt, but like you said, it's a wonder I can communicate directly with you, and because of that, I want to help you.", "Ida"));
        dialogTexts.Add(new DialogData("Huh?", "Ida"));
        dialogTexts.Add(new DialogData("There's reason to believe that there's more to your disappearance than meets the eye.", "Medium"));
        dialogTexts.Add(new DialogData("Sure, the case doesn't really have a leg to stand on, but you being here right now confirms that you did die here- we just don't know anything else aside from that.", "Medium"));
        dialogTexts.Add(new DialogData("Please, I know you're just as in the dark as us right now, but just let me conduct my investigation and maybe we can find out together.", "Medium"));
        dialogTexts.Add(new DialogData("You can finally escape this cycle of pain you've found yourself in for the past 70 years.", "Medium"));
        dialogTexts.Add(new DialogData("Please. Just give me a chance.", "Medium"));
        dialogTexts.Add(new DialogData("... You drive a hard bargain.", "Ida"));
        dialogTexts.Add(new DialogData("Fine, I'll let you take a look around, but first, I'd like you to do something for me.", "Ida"));
        dialogTexts.Add(new DialogData(" Be a dear and light the fireplace, will ya?", "Ida"));
        dialogTexts.Add(new DialogData("You'll need matches and some tinder to get the fire going- they're all hiding around here somewhere", "Ida"));
        dialogTexts.Add(new DialogData("Now get on with it, and no funny business, alright?", "Ida"));
        dialogTexts.Add(new DialogData("/emote:Anger/Remember, I'm watching you.", "Ida"));
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
            //dialogTexts.Add(new DialogData("/color:#540647/Get out of my house.", "Ida"));

            DialogManager.Show(dialogTexts);
        }
        else if (GameState.FirstPuzzleComplete == GameManager.Instance.State && room == "foyer")
        {
            var dialogTexts2 = new List<DialogData>();
            dialogTexts2.Add(new DialogData("Stop messing around", "Ida"));
            dialogTexts2.Add(new DialogData("But...", "Ida"));
            dialogTexts2.Add(new DialogData("...", "Ida"));

            DialogManager.Show(dialogTexts2);
        }

        else if (GameState.StartGame == GameManager.Instance.State && room == "livingRoom")
        {
            var dialogTexts2 = new List<DialogData>();
            dialogTexts2.Add(new DialogData("... stop touching my things", "Ida"));
            DialogManager.Show(dialogTexts2);
        }

        else if (GameState.FirstPuzzleComplete == GameManager.Instance.State && room == "livingRoom")
        {
            var dialogTexts2 = new List<DialogData>();
            dialogTexts2.Add(new DialogData("...", "Ida"));
            dialogTexts2.Add(new DialogData("...", "Ida"));
            dialogTexts2.Add(new DialogData("Why can't I remember...", "Ida"));
            DialogManager.Show(dialogTexts2);
        }
    }

    //Scrap?
    /*public void ida_interaction_1()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Who are you.", "Ida"));
        dialogTexts.Add(new DialogData("What do you want.", "Ida"));
        dialogTexts.Add(new DialogData("/color:#540647/Get out of my house.", "Ida"));

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
            dialogTexts.Add(new DialogData("This is quite an interesting piece of art.", "Medium"));
            dialogTexts.Add(new DialogData("Oh that. That used to belong to our parents, when this used to be their room- funny little thing isn't it? One big picture made of 8 painted wooden tiles in a frame.", "Ida"));
            dialogTexts.Add(new DialogData("You could slide them around and try to put them back in place afterwards.", "Ida"));
            dialogTexts.Add(new DialogData("Of course, they're all messed up right now. I don't see how putting them back together will do anything though.", "Ida"));
            dialogTexts.Add(new DialogData("Let me see...", "Medium"));
            DialogManager.Show(dialogTexts);
            puzzle1_tutorial = false;
        }
    }

    public void postPuzzleDialogue_1()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Ah, that must be what it's supposed to look like. Wait… something fell out from behind one of the tiles.", "Medium"));
        dialogTexts.Add(new DialogData("/color:#540647//size:40/[Found: Strange Key]", "SYSTEM"));
        dialogTexts.Add(new DialogData("Another key? I can't imagine what this would be for.", "Medium"));
        dialogTexts.Add(new DialogData("!", "Ida"));
        dialogTexts.Add(new DialogData("Huh? You recognize this, Miss Wagner?", "Medium"));
        dialogTexts.Add(new DialogData("Come over here, by the closet.", "Ida"));
        dialogTexts.Add(new DialogData("Huh, there's nothing in here that seems out of the ordinary. Wait, what's that hatch up there? ", "Medium"));
        dialogTexts.Add(new DialogData("/sound:KeyClick/(Click) Hey, the key fits in this hole!", "Medium")); // SOUND
        dialogTexts.Add(new DialogData("(Creak) A set of pull out stairs?.", "Medium")); // SOUND
        dialogTexts.Add(new DialogData("This is the attic. Strange place to put the entrance, I know, but it's been here since it was built. Only the people who live here should know about it.", "Ida"));
        dialogTexts.Add(new DialogData("Well, there's no way left but up. ", "Medium"));

        DialogManager.Show(dialogTexts);

    }
    #endregion

    // Clock Puzzle DIalogue
    #region
    public void prePuzzle2()
    {
         if (puzzle2_intro)
        {

            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("(Wasn't there a piece of paper with a time written on it downstairs? Maybe I should keep that in mind.)", "Medium"));
            dialogTexts.Add(new DialogData("(It looks like I can move the hands on this.)", "Medium"));
            dialogTexts.Add(new DialogData("How do I keep track of the numbers again?... Hm, this is why I prefer digital.", "Medium"));
            dialogTexts.Add(new DialogData("You mean to tell me there's clocks other than this kind?", "Ida"));
            dialogTexts.Add(new DialogData("There's a lot you have to learn about the present day- but if I stood here filling you in on all that's happened, we'd be here forever.", "Medium"));

            DialogManager.Show(dialogTexts);
            puzzle2_intro = false;
        }
    }
    
    public void postPuzzleDialogue_2()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("/sound:ClockChime/... That says 11:45 right?", "Medium"));
        dialogTexts.Add(new DialogData("...", "Ida"));
        dialogTexts.Add(new DialogData("Yes", "Ida"));
        dialogTexts.Add(new DialogData("/sound:KeyClick/(Oh, the clock popped open! There's something jammed inside, too)", "Medium")); // <Key/metal sound effect>
        dialogTexts.Add(new DialogData("/color:#540647//size:40/[Found: Spare Key]", "SYSTEM"));
        dialogTexts.Add(new DialogData("Oh, so THAT'S where I left it!", "Ida"));
        dialogTexts.Add(new DialogData(" I don't remember why or how it ended up there, but it looks like we can finally get into my room.", "Ida"));
        dialogTexts.Add(new DialogData("(We're in the home stretch-I'm sure that the answers we need are behind that door. Alright, let's do this.)", "Medium"));
        dialogTexts.Add(new DialogData("/color:#540647//size:40/[Room Unlocked: Master Bedroom]", "SYSTEM"));

        DialogManager.Show(dialogTexts);
        
    }

    public void postPuzzleDialogue_3()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Well I'll be, you did it.", "Ida")); // <Fire roars to life>
        dialogTexts.Add(new DialogData("And I got quite a bit of new evidence- thanks to your cooperation, of course.", "Medium"));
        dialogTexts.Add(new DialogData("Now that I think about it... I think I remember a little bit more about the night of the party.", "Ida"));
        dialogTexts.Add(new DialogData("Hm?", "Medium"));
        dialogTexts.Add(new DialogData("As I mentioned, I started the night off with a performance, then after that, I mingled with the guests for about an hour or so.", "Ida"));
        dialogTexts.Add(new DialogData("Thing is, I might've gotten a bit heavy with the hooch, if you know what I mean.", "Ida"));
        dialogTexts.Add(new DialogData("At first I was sorta just stumbling around but after a while I was helped up the stairs-you know, to take a break and get it together.", "Ida"));
        dialogTexts.Add(new DialogData("What next?", "Medium"));
        dialogTexts.Add(new DialogData("... I think we need to go upstairs. You seem to be on the up and up, so I think I can trust you to continue.", "Ida"));
        dialogTexts.Add(new DialogData("/color:#540647//size:40/[Second Level Unlocked: Upstairs Hallway]", "SYSTEM"));

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
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("I am an item. Edit my text in MasterScript."));
            DialogManager.Show(dialogTexts);
        }


        else if (keyWord == "bottle")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("Hey, hey, I thought you weren't here for that!", "Ida"));
            dialogTexts.Add(new DialogData("(Sigh)", "Medium"));
            dialogTexts.Add(new DialogData("Sorry. I forgot you guys didn't exactly have the privilege of cracking open a cold one out in the open back then.", "Medium"));
            dialogTexts.Add(new DialogData("Say, where'd you get this stuff anyways?", "Medium"));
            dialogTexts.Add(new DialogData("....", "Ida"));
            dialogTexts.Add(new DialogData("I swear this info is needed for the investigation.", "Medium"));
            dialogTexts.Add(new DialogData("... (Sigh)", "Ida"));
            dialogTexts.Add(new DialogData("How do I even begin to describe him?", "Ida"));
            dialogTexts.Add(new DialogData("Him? ", "Medium"));
            dialogTexts.Add(new DialogData("His name was Raymond Hyde. Real shady guy, never liked him all that much. ", "Ida"));
            dialogTexts.Add(new DialogData("Still, he was... in my circle, whether I liked it or not.", "Ida"));
            dialogTexts.Add(new DialogData("At first, I didn't want to do business with him, but in the end, he made an offer I couldn't refuse. ", "Ida"));
            dialogTexts.Add(new DialogData("After all, it ain't New Year's without some good drinks, and I couldn't let my guests go thirsty.", "Ida"));
            dialogTexts.Add(new DialogData("Even if I had to get my bootleg from him, of all people.", "Ida"));
            dialogTexts.Add(new DialogData("Hm. I'll keep that in mind.", "Medium"));
            //dialogTexts.Add(new DialogData("(Hey, there seems to be something stuck underneath one of the bottles.)", "Medium"));
            //dialogTexts.Add(new DialogData("(Hm. It's a paper party invitation. Maybe I can use this for the fire.)", "Medium"));
            //dialogTexts.Add(new DialogData("/color:#540647/[Found: Party Invite]", "SYSTEM"));
            /* dialogTexts.Add(new DialogData("Hey Miss Wagner, you wouldn't mind if I used this to get the fire going, would you?", "Medium"));
             dialogTexts.Add(new DialogData("It's not like anyone else needs them right now. ", "Medium"));*/
            //dialogTexts.Add(new DialogData("...I suppose. You're gonna need more than just one, though.", "Ida"));

            DialogManager.Show(dialogTexts);
        }

        else if (keyWord == "Chandelier")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("An old chandelier... hope it doesn't fall.", "Medium"));
            DialogManager.Show(dialogTexts);
        }

        else if (keyWord == "Wallpaper")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("This place is really falling apart...", "Medium"));
            dialogTexts.Add(new DialogData("But maybe I can burn this.", "Medium"));
            dialogTexts.Add(new DialogData("/color:#540647//size:40/[Found: Kindle]", "SYSTEM"));
            DialogManager.Show(dialogTexts);
        }
        else if (keyWord == "Gramophone")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("(It's weird that this thing still works after all this time...)", "Medium"));
            dialogTexts.Add(new DialogData("It was always one of my go-tos at the club where I used to work. I even started the party with my rendition of it.", "Ida"));
            dialogTexts.Add(new DialogData("It's funny... I had this whole shindig to really put myself out there, you know?", "Ida"));
            dialogTexts.Add(new DialogData("Maybe I could rub elbows with some big shots, make some connections, nab a major gig, and really become a star... ", "Ida"));
            dialogTexts.Add(new DialogData("I didn't even make it to midnight.", "Ida"));
            dialogTexts.Add(new DialogData("... Miss Wagner?", "Medium"));
            dialogTexts.Add(new DialogData("...Wait, you didn't hear all that, didn't you?", "Ida"));
            //dialogTexts.Add(new DialogData("J-just forget I said anything. Hey look,  something you should pay more attention to!", "Ida"));
            /* dialogTexts.Add(new DialogData("(She's right, there's something stuffed inside the bell of the gramophone.)", "Ida"));
             dialogTexts.Add(new DialogData("/color:#B45ACF/[Found: Party Invite].", "SYSTEM"));*/
            DialogManager.Show(dialogTexts);
        }
        else if (keyWord == "Chest")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("(Hey, there seems to be something in here.)", "Medium"));
            dialogTexts.Add(new DialogData("/color:#540647//size:40/[Found: Box of Matches].", "SYSTEM"));
            DialogManager.Show(dialogTexts);
        }
        else if (keyWord == "puzzle1_nogo")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("Can't light this just yet.", "Medium"));
            DialogManager.Show(dialogTexts);
        }
        else if (keyWord == "puzzle1_goahead")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("Alright... let's try this.", "Medium"));
            DialogManager.Show(dialogTexts);
        }
        else if (keyWord == "Books")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("The books are coated in a thick layer of dust...", "Medium"));
            dialogTexts.Add(new DialogData("/sound:Paper/Hm? There's a piece of paper sticking out from one of them.", "Medium"));
            dialogTexts.Add(new DialogData("...?", "Medium"));
            DialogManager.Show(dialogTexts);

        }
        else if (keyWord == "Door")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("It's locked...", "Medium"));
            DialogManager.Show(dialogTexts);

        }
        else if (keyWord == "Picture")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("(This seems to be a family portrait from when Ida was younger. The younger girl next to her must be Pearl.) ", "Medium"));
            dialogTexts.Add(new DialogData("So, Miss Wagner, can you tell me a bit more about your sister?", "Medium"));
            dialogTexts.Add(new DialogData("Pearl was my closest friend, to say the least.", "Ida"));
            dialogTexts.Add(new DialogData("We've always had each other's backs, especially ever since we lost our parents. ", "Ida"));
            dialogTexts.Add(new DialogData("She's a real sweet girl but a bit too trusting sometimes.", "Ida"));
            dialogTexts.Add(new DialogData("I appreciate that she tried to see the best in everyone, but it was still easy for her to get mixed up with the wrong type of people.", "Ida"));
            dialogTexts.Add(new DialogData("What kind of people?", "Medium"));
            dialogTexts.Add(new DialogData("...The kind of people who will hook you up with bootleg for the biggest party of your life even when you hate their guts", "Ida"));
            dialogTexts.Add(new DialogData(" You don't mean-", "Medium"));
            dialogTexts.Add(new DialogData("Yeah. Raymond was… my brother-in-law.", "Ida"));
            dialogTexts.Add(new DialogData("He and Pearl got hitched about a year before this all went down, and I felt he was just all kinds of wrong.", "Ida"));
            dialogTexts.Add(new DialogData("I could tell he was in with some powerful but dangerous folks- and yet Pearl was crazy for him.", "Ida"));
            dialogTexts.Add(new DialogData("I dropped a few hints to her that she should be a bit more careful, but as far as she was concerned, Raymond was the one. ", "Ida"));
            dialogTexts.Add(new DialogData("They seemed alright enough when they were together, though.", "Ida"));
            dialogTexts.Add(new DialogData("And I didn't want to make things worse by sticking my nose where it didn't belong, so I just put up with the whole thing as much as I could. ", "Ida"));
            dialogTexts.Add(new DialogData("I see.", "Medium"));
            dialogTexts.Add(new DialogData("Aside from all that though, Pearl really was the best sister a girl could ask for.", "Ida"));
            dialogTexts.Add(new DialogData("She helped me “out of my shell” while we were growing up, she encouraged me to pursue my music career when I had my doubts- she even helped me with planning this party…. ", "Ida"));
            dialogTexts.Add(new DialogData(" I hope I did as much for her as she did for me.", "Ida"));
            dialogTexts.Add(new DialogData("...", "Medium"));
            DialogManager.Show(dialogTexts);
        }
       
        else if (keyWord == "Teacup")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("(This must've fallen out of Ida's hands after she lost consciousness.)", "Medium"));
            dialogTexts.Add(new DialogData("Miss Wagner, can you be more specific in describing what happened when you drank that tea?", "Medium"));
            dialogTexts.Add(new DialogData("Well, I did notice there was a kind of funny taste to it- definitely brought me back to my senses for a split second.", "Ida"));
            dialogTexts.Add(new DialogData("Like in the sense that there was something else mixed in? Something that shouldn't have been in there?", "Medium"));
            dialogTexts.Add(new DialogData("If you're saying what I think you're saying…", "Ida"));
            dialogTexts.Add(new DialogData("Yes.", "Medium"));
            dialogTexts.Add(new DialogData("Then yes.", "Ida"));
            dialogTexts.Add(new DialogData("Well, putting two and two together, I'd say this is a textbook case of poisoning.", "Medium"));
            dialogTexts.Add(new DialogData("Now hold on there, you better not be trying to pin this on Pearl so quickly, alright?!", "Ida"));
            dialogTexts.Add(new DialogData("I'm not saying anything, I'm just keeping the facts in mind. ", "Medium"));

            DialogManager.Show(dialogTexts);
        }
        else if (keyWord == "Attic Door")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("/sound:Doorknob/It's locked...", "Medium")); // <Door knob jiggle>
            DialogManager.Show(dialogTexts);
        }

        else if(keyWord == "Paper Scrap")
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("/sound:Paper/(What's this sticking out from under the dresser?)", "Medium"));
            dialogTexts.Add(new DialogData("/color:#540647//size:40/[Found: Note]", "SYSTEM"));
            dialogTexts.Add(new DialogData(" Let's see what this says… oh. This is… interesting.", "Medium"));
            dialogTexts.Add(new DialogData("Huh? Let me see!.", "Ida"));
            dialogTexts.Add(new DialogData("...", "Ida"));

            DialogManager.Show(dialogTexts);
        }

        else if (keyWord == "Attic Chest")
        {
            // CUT THE MUSIC ??
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("(There's no going back. Time to literally crack the case wide open)", "Medium"));
            dialogTexts.Add(new DialogData("/sound:ChestOpen/...", "Medium"));
            dialogTexts.Add(new DialogData("...", "Ida"));
            dialogTexts.Add(new DialogData("Oh god.", "Medium"));
            dialogTexts.Add(new DialogData("That…that's me. I almost couldn't tell at first, it's just… I never thought I would see myself like this.", "Ida"));
            dialogTexts.Add(new DialogData("...", "Medium"));
            dialogTexts.Add(new DialogData("I-... I can't explain it but…I want to be mad. I want to be mad at the life I never got to live, all the possibilities I never knew, all the memories I could've made but… I can't. ", "Ida"));
            dialogTexts.Add(new DialogData("...How do you feel?", "Medium"));
            dialogTexts.Add(new DialogData("...Tired. I'm just tired. I've spent the past 70 or so years just stewing in my anger but now that I have a reason for it, I've already burnt out.", "Ida"));
            dialogTexts.Add(new DialogData("But come to think of it... there's not much else I can do, can I? What should I do??", "Ida"));
            dialogTexts.Add(new DialogData("Well, I would say that, if you're tired, you should rest. Seems simple enough. There's nothing else keeping you here. ", "Medium"));
            dialogTexts.Add(new DialogData("It might seem daunting to accept, but it can't be worse than what you've already been through.", "Medium"));
            dialogTexts.Add(new DialogData("In the end, of course, it's your decision.", "Medium"));
            dialogTexts.Add(new DialogData("...It's a shame, ya know. You've been the first person I've talked to in ages… I wish I could've gotten to know you better.", "Ida"));
            dialogTexts.Add(new DialogData("Even then…you're right. It's curtains for me.", "Ida"));
            dialogTexts.Add(new DialogData("I don't know what's next, but I'm not afraid to find out.", "Ida"));
            dialogTexts.Add(new DialogData("Thank you, Inspector. You really were the bee's knees, ya know?", "Ida"));
            DialogManager.Show(dialogTexts);
            endGameManager.SetActive(true);
            GameManager.Instance.UpdateGameState(GameState.EndGame);
            

        }
    }

    #endregion

    #region
    // TO TRIGGER AT THE FIRST CLICK OF A NAVIGATION ARROW

    public void upstairsUnlocked()
    {
        if (upstairsIntro)
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("So, as you were saying?", "Medium"));
            dialogTexts.Add(new DialogData("Well, it's all still a bit fuzzy, but I think my sister Pearl dragged me out of the crowd and helped me upstairs.", "Ida"));
            dialogTexts.Add(new DialogData("From there, she brought me over to my room, talkin' about how I should sit things out for a while.", "Ida"));
            dialogTexts.Add(new DialogData("Of course, I was going on about how I was fine and that they needed me downstairs but she insisted.", "Ida"));
            dialogTexts.Add(new DialogData("Sounds good, let's head in and-", "Medium"));
            dialogTexts.Add(new DialogData("/sound:Doorknob/(Doorknob rattles)", "Medium")); // TRIGGER SOUND
            dialogTexts.Add(new DialogData("What? Really?", "Ida"));
            dialogTexts.Add(new DialogData("...There's no way. I couldn't have been THAT drunk, could I?", "Ida"));
            dialogTexts.Add(new DialogData("Why the hell would it be locked?", "Ida"));
            dialogTexts.Add(new DialogData("Hpmh, it's nothing. I think I had a spare key lying here somewhere.", "Ida"));
            dialogTexts.Add(new DialogData("If you look around, you'll find it soon enough.", "Ida"));
            upstairsIntro = false;
            DialogManager.Show(dialogTexts);
        }
    }

    public void bedroomUnlocked()
    {
        if (bedroomIntro)
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("Alright, we're finally here- any new memories coming back to you, Miss Wagner?", "Medium"));
            dialogTexts.Add(new DialogData(" Hmm... Well, Pearl propped me up in bed after she brought me in here, then left to go check on things downstairs.", "Ida"));
            dialogTexts.Add(new DialogData("I don't know how long I was just lying here, but it was definitely a while.", "Ida"));
            dialogTexts.Add(new DialogData("Then she came back, carrying a cup of my favorite tea. I was just awake enough to take a few sips but that's where things went dark.", "Ida"));
            dialogTexts.Add(new DialogData("If it's what I think it is...", "Medium"));
            dialogTexts.Add(new DialogData("L-let's at least get all our facts straight first. There's probably a lot in this room to uncover.", "Ida"));
            dialogTexts.Add(new DialogData("Very well. I'll get to searching.", "Medium"));
            DialogManager.Show(dialogTexts);
            bedroomIntro = false;
        }
    }

    public void attackUnlocked()
    {
        if (atticIntro)
        {
            var dialogTexts = new List<DialogData>();
            dialogTexts.Add(new DialogData("(Cough) Eugh, it's dusty in here. Wait, what's that big chest over there?", "Medium"));
            dialogTexts.Add(new DialogData("...", "Ida"));
            dialogTexts.Add(new DialogData("...", "Ida"));
            dialogTexts.Add(new DialogData("I think I know the answer to that. But being face-to-face with it, I can't bring myself to look.", "Ida"));
            dialogTexts.Add(new DialogData("Why not?", "Medium"));
            dialogTexts.Add(new DialogData("I know we've already come so far, and you've been such a big help, but I feel like I'm not gonna like the answers we've been looking for.", "Ida"));
            dialogTexts.Add(new DialogData("...I understand. In my time doing this work, there's many things that are hard to confront. ", "Medium"));
            dialogTexts.Add(new DialogData("But if I can say something, just know that you won't face this alone. I'm here.", "Medium"));
            dialogTexts.Add(new DialogData("...Thanks", "Ida"));
            DialogManager.Show(dialogTexts);
            
            atticIntro = false;
        }
    }
    #endregion





   
}
