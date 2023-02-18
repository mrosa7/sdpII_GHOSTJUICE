using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// This is calling a dialogue when ever the ghost is clicked. What dialogue is being called depends on the state,
// state can be updated publicly. Say, after a puzzle, the dialogue can change. Maybe depending on room? How would i handle that?
public class Ghost_Dialog_State : MonoBehaviour, IPointerClickHandler
{
    public inGameDialogManager IG_DialogManager;
    public string GhostState;

    private void Start()
    {
        GhostState = "inital";
    }
    // Start is called before the first frame update

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("IM BEING CLICKED");
        IG_DialogManager.IdaInteraction(GhostState);
    }
}
