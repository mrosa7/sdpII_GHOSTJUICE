using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Interactable : MonoBehaviour, IPointerClickHandler
{
    //TO ADD INTERACTABLE OBJECT:
    //Create object with 2d collider w/ trigger checked off. 
    SpriteRenderer spriteRenderer;
    public string keyWord;
    public GameObject itemDisplayBox; // connect to itemDisplay in Dialog Asset
    Image targetImage;
    //public inGameDialogManager IG_DialogManager;


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

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
        Debug.Log("UR SUPPOSE TO SAY SOMETHING DAMMNIT");
        displayItem();
        MASTERSCRIPT.Instance.objInteraction(keyWord);
    }

    void displayItem()
    {
        itemDisplayBox.SetActive(true);
        Image targetImage = itemDisplayBox.GetComponent<Image>();
        targetImage.sprite = spriteRenderer.sprite;
        targetImage.rectTransform.localScale = new Vector3(4, 4, 1);
    }
}
