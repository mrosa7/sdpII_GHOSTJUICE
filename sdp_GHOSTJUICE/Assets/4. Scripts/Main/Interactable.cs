using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;


public class Interactable : MonoBehaviour, IPointerClickHandler
{
    //TO ADD INTERACTABLE OBJECT:
    //Create object with 2d collider w/ trigger checked off. 
    SpriteRenderer spriteRenderer;
    public string keyWord;
    public GameObject itemDisplayBox; // connect to itemDisplay in Dialog Asset
    Image targetImage;
    RectTransform sourceRectT;
    
    //public inGameDialogManager IG_DialogManager;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        sourceRectT = GetComponent<RectTransform>();

    }

    private void OnMouseOver()
    {
        spriteRenderer.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white; ;
    }

    //when interacting with object
    public void OnPointerClick(PointerEventData eventData)
    {
       // Debug.Log("UR SUPPOSE TO SAY SOMETHING DAMMNIT");
        displayItem();
        Debug.Log("CLICKING:" + name);
        MASTERSCRIPT.Instance.objInteraction(keyWord);
        objectiveTriggerCheck(keyWord);
    }

    void displayItem()
    {
        itemDisplayBox.SetActive(true);
        
        SpriteRenderer targetImage = itemDisplayBox.GetComponent<SpriteRenderer>();
        RectTransform targetRect = itemDisplayBox.GetComponent<RectTransform>();
        targetImage.sprite = spriteRenderer.sprite;
       
        targetRect.localScale = new Vector3(1.5f, 1.5f, 1);

        //targetRect.sizeDelta = new Vector2(sourceRectT.sizeDelta.x*100,sourceRectT.sizeDelta.y*100); 
       
    }

    void objectiveTriggerCheck(string key)
    {
        if (key == "Chest")
        {
            GameObject textToStrike = GameObject.Find("obj1_text");
            TMP_Text text = textToStrike.GetComponent<TMPro.TextMeshProUGUI>();
            text.fontStyle = FontStyles.Strikethrough;
            GameManager.Instance.objective1_matches = true;

        }

        else if (key == "bottle")
        {
            GameObject textToStrike = GameObject.Find("obj1_text2");
            TMP_Text text = textToStrike.GetComponent<TMPro.TextMeshProUGUI>();
            text.fontStyle = FontStyles.Strikethrough;
            GameManager.Instance.objective1_paper = true;
        }
    }
}
