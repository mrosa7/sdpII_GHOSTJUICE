using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Puzzle1_trigger : MonoBehaviour, IPointerClickHandler
{
    SpriteRenderer spriteRenderer;
    public GameObject PuzzleToShow;
    public GameObject UIToHide;
    public GameObject TriggerToHide;
    public GameObject ObjTxtToHide;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(GameManager.Instance.objective1_matches == false || GameManager.Instance.objective1_paper == false)
        {
            MASTERSCRIPT.Instance.objInteraction("puzzle1_nogo");       
        }
        else
        {
            MASTERSCRIPT.Instance.objInteraction("puzzle1_goahead");
            PuzzleToShow.SetActive(true);
            UIToHide.SetActive(false);
            TriggerToHide.SetActive(false);
            ObjTxtToHide.SetActive(false);
            
        }
       
    }

    private void OnMouseOver()
    {
        spriteRenderer.color = Color.yellow;
    }
    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white; ;
    }
}
