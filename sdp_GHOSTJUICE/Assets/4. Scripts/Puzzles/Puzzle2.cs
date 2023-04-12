using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle2 : MonoBehaviour
{
    public GameObject hourHand;
    public GameObject minuteHand;

    public GameObject hourGRAB;
    public GameObject minuteGRAB;

    public GameObject hourArea;
    public GameObject minuteArea;

    public GameObject targetToHide;

    Collider2D hourHand_Col;
    Collider2D minuteHand_Col;

    private Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;

    public float innerRadMin;
    public float outerRadMin;

    bool isMoving;
    bool isMovingHour;
    bool isMovingMinute;

    bool hourIsSolved = false;
    bool minuteIsSolved = false;
    bool isSolved = false;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        hourHand_Col = hourGRAB.GetComponent<Collider2D>(); // get collider to rotate
        minuteHand_Col = minuteGRAB.GetComponent<Collider2D>();
        isMovingHour = false; // set bools. Nothing should be moving
        isMovingMinute = false;
        isMoving = false;

        MASTERSCRIPT.Instance.prePuzzle2();

       
    }
    /*private void Update()
    {
        if (hourHand_Col.bounds.Intersects(solvedHour_Col.bounds))
        {
            Debug.Log("hour is solved");
            if (minuteHand_Col.bounds.Intersects(solvedMinute_Col.bounds))
            {
                Debug.Log("minute is solved");
                Solved();
                //enabled = false;
            }
        }
       
    }*/

    void checkSolved()
    {
        // checks if both the hour and minute is in the right place. 
        hourIsSolved = hourHand.GetComponent<Puzzle2_HandCollision>().isSolved;
        minuteIsSolved = minuteHand.GetComponent<Puzzle2_HandCollision>().isSolved;
        if(minuteIsSolved && hourIsSolved)
        {
            Solved();
        }
    }
    void Solved()
    {
        Debug.Log("Running Solved Protocol");
        GameManager.Instance.UpdateGameState(GameState.SecondPuzzleComplete);
        MASTERSCRIPT.Instance.postPuzzleDialogue_2();
        isSolved = true;
        enabled = false;
    }

    public void changeEnviron()
    {
        if (isSolved)
        {
            targetToHide.SetActive(false);
        }
        else
        {
            targetToHide.SetActive(true);
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);

        // if mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            if (isMoving == false) // if it wasn't already moving
            {
                // if the player clicked on the hour hand collider wheel.
                if (hourHand_Col == Physics2D.OverlapPoint(mousePos))
                {   
                    //update who is moving
                    isMoving = true;
                    isMovingHour = true;
                    isMovingMinute = false;
                    // get distance of the click from the origin of this game object (puzzle manager 2)
                    // if its below a certain distance, it knowns to move the hour hand collider. I have this check here bc they overlap.
                    float distance = Vector2.Distance(Physics2D.OverlapPoint(mousePos).transform.position, transform.position);

                    if (innerRadMin <= distance && isMovingHour == true)
                    { //Calculate the movement of hour hand game object.
                        //Debug.Log("I'm being Rotated??");
                        screenPos = myCam.WorldToScreenPoint(transform.position);
                        Vector3 vec3 = Input.mousePosition - screenPos;
                        angleOffset = (Mathf.Atan2(hourHand.transform.right.y, hourHand.transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
                        //Debug.Log(angleOffset);
                    }

                }
                else if (minuteHand_Col == Physics2D.OverlapPoint(mousePos))
                {
                    //update who is moving.
                    isMoving = true;
                    isMovingMinute = true;
                    isMovingHour = false;
                    float distance = Vector2.Distance(Physics2D.OverlapPoint(mousePos).transform.position, transform.position);
                    // get distance of the click from the origin of this game object (puzzle manager 2)
                    // if its above a certain distance, it knowns to move the minute hand collider. I have this check here bc they overlap.
                    if (distance >outerRadMin && isMovingMinute == true)
                    {
                        //Calculate the movement of minute hand game object.
                        screenPos = myCam.WorldToScreenPoint(transform.position);
                        Vector3 vec3 = Input.mousePosition - screenPos;
                        angleOffset = (Mathf.Atan2(minuteHand.transform.right.y, minuteHand.transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
                        //Debug.Log(angleOffset);
                    }
                }
            }

        }

        // runs as the mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            if (isMoving == true)
            {
                
                //updates hour hand based on above calculation
                if (hourHand_Col == Physics2D.OverlapPoint(mousePos)&& isMovingHour == true)
                {
                    hourArea.SetActive(true);
                    //Debug.Log("I'm being Rotated2222222??");
                    Vector3 vec3 = Input.mousePosition - screenPos;
                    float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                    hourHand.transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
                    //hourGRAB.transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
                }
                //updates minute hand based on above calculation
                if (minuteHand_Col == Physics2D.OverlapPoint(mousePos) && isMovingMinute == true)
                {
                    minuteArea.SetActive(true);
                    //Debug.Log("I'm being Rotated2222222??");
                    Vector3 vec3 = Input.mousePosition - screenPos;
                    float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                    minuteHand.transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
                    //hourGRAB.transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
                }
            }

        }
        // if mmouse is released. 
        // stop moving everything. 
        if (Input.GetMouseButtonUp(0))
        {
            isMovingHour = false;
            isMovingMinute = false;
            isMoving = false;
            hourArea.SetActive(false);
            minuteArea.SetActive(false);
        }

        checkSolved(); // check if they are in the correct spot.
    }

}
