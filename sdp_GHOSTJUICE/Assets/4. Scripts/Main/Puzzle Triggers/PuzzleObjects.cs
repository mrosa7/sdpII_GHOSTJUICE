using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PuzzleObjects : MonoBehaviour, IPointerClickHandler
{
    SpriteRenderer spriteRenderer;
    public GameObject PuzzleToShow;
    public GameObject UIToHide;
    public GameObject TriggerToHide;
    public GameObject ObjectToHide;
    
    //public string keyWord;
    //public GameObject itemDisplayBox; // connect to itemDisplay in Dialog Asset
    //Image targetImage;
    //RectTransform sourceRectT;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    public void OnPointerClick(PointerEventData eventData)
    {
        PuzzleToShow.SetActive(true);
        UIToHide.SetActive(false);
        TriggerToHide.SetActive(false);
        ObjectToHide.SetActive(false);
        GameManager.Instance.canClickObj = false;
    }

    private void OnMouseOver()
    {
        spriteRenderer.color = Color.magenta;
    }
    private void OnMouseExit()
    {
        spriteRenderer.color = Color.white; ;
    }

    public void allowClicks()
    {
        GameManager.Instance.canClickObj = true;
    }
}
