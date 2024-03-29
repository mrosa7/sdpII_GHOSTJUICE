using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzzle3_matchStick : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    Vector3 startPos;
    public float speed;
    public GameObject lBound;
    public GameObject hBound;
    bool canClick;
    GameObject selectedObject;
    Vector3 offset;
    float timer;
    public GameObject objective;
    public GameObject objective2;
    public GameObject trigger;
    public GameObject litFireAsset;
    public bool isSolved = false;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        canClick = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        transform.position = Vector3.Lerp(transform.position,
            transform.position + movement,
            Time.deltaTime * speed);*/
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
               offset = selectedObject.transform.position - mousePosition;
            }
        }
        if (canClick)
        {
            if (selectedObject != null && selectedObject.name == "Match_stick (MANAGER)")
            {
                selectedObject.transform.position = new Vector3(startPos.x, mousePosition.y + offset.y);
                if (selectedObject.transform.position.y <= lBound.transform.position.y)
                {
                    selectedObject.transform.position = new Vector3(startPos.x, lBound.transform.position.y);
                }
                else if (selectedObject.transform.position.y >= hBound.transform.position.y)
                {
                    selectedObject.transform.position = new Vector3(startPos.x, hBound.transform.position.y);
                }

            }
        }

        if (Input.GetMouseButtonUp(0) && selectedObject != null && selectedObject.name == "Match_stick (MANAGER)")
        {

            selectedObject = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "MatchBox")
        {
            timer = 0f;
            Debug.Log("HIT");
        }
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "MatchBox")
        {
            timer += Time.deltaTime;
           
        }
        if (Input.GetMouseButtonUp(0)){
            Debug.Log("Fail");
            canClick = false;
            // play sound effect
            StartCoroutine(moveToStart(gameObject, startPos));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "MatchBox")
        {
            if (timer <= 0.3f)
            {
                litFireAsset.SetActive(true);
                                
                if(isSolved == false) // FIXES PUZZLE CONVO DUPE
                {
                    canClick = false;
                    isSolved = true;
                    endPuzzleFunc();
                }
                
                 //play sound effect
            }
            else
            {
                Debug.Log("Fail");
                canClick = false;
                // play sound effect
                StartCoroutine(moveToStart(gameObject, startPos));
                /*if (collision == collision.isActiveAndEnabled)
                {
                    
                }*/
            }
            audioSource.PlayOneShot(audioClip, 0.7f);

        }
    }

    IEnumerator moveToStart(GameObject objToMove, Vector3 target) 
    {
        float timeElapsed = 0;

        while (timeElapsed <= 0.2)
        {
            objToMove.transform.position = Vector3.Lerp(objToMove.transform.position, target, timeElapsed / 0.2f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        canClick = true;
        timer = 0f;
    }

    public void puzzlePassed()
    {
        if(isSolved == false)
        {
            trigger.SetActive(true);
        }
        else
        {

            litFireAsset.SetActive(true);
           
        }
    }

    void endPuzzleFunc()
    {
        trigger.SetActive(false);
        GameManager.Instance.UpdateGameState(GameState.FirstPuzzleComplete);
        MASTERSCRIPT.Instance.postPuzzleDialogue_3();
        objective2.SetActive(false);
        TMP_Text text = objective.GetComponent<TMPro.TextMeshProUGUI>();
        text.SetText("Explore the Wagner House");
    }
}
