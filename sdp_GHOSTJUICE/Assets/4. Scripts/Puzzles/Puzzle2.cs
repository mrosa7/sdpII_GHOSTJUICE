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

    Collider2D hourHand_Col;
    Collider2D minuteHand_Col;
    
    public GameObject solvedHour;
    public GameObject solvedMinute;
    Collider2D solvedHour_Col;
    Collider2D solvedMinute_Col;

    private Camera myCam;
    private Vector3 screenPos;
    private float angleOffset;

    public float innerRadMin;

    // Start is called before the first frame update
    void Start()
    {
        myCam = Camera.main;
        hourHand_Col = hourGRAB.GetComponent<Collider2D>();
        minuteHand_Col = minuteGRAB.GetComponent<Collider2D>();

       // solvedHour_Col = solvedHour.GetComponent<Collider2D>();
       // solvedMinute_Col = solvedMinute.GetComponent<Collider2D>();
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

    void Solved()
    {
        Debug.Log("Running Solved Protocol");
        // Start dialogue Sequence
        // Advance Game state
        enabled = false;
    }

    /* void Update()
     {
         Vector2 direction = myCam.ScreenToViewportPoint(Input.mousePosition) - transform.position;
         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
         Quaternion rotation = Quaternion.AngleAxis(angle-90,Vector3.forward);
         transform.rotation = rotation;
     }*/
    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = myCam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {

            if (hourHand_Col == Physics2D.OverlapPoint(mousePos))
            {
                float distance = Vector2.Distance(Physics2D.OverlapPoint(mousePos).transform.position, transform.position);

                if (innerRadMin <= distance)
                {
                    //Debug.Log("I'm being Rotated??");
                    screenPos = myCam.WorldToScreenPoint(transform.position);
                    Vector3 vec3 = Input.mousePosition - screenPos;
                    angleOffset = (Mathf.Atan2(hourHand.transform.right.y, hourHand.transform.right.x) - Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;
                    Debug.Log(angleOffset);
                }
                
            }
        }
        if (Input.GetMouseButton(0))
        {

            if (hourHand_Col == Physics2D.OverlapPoint(mousePos))
            {
                //Debug.Log("I'm being Rotated2222222??");
                Vector3 vec3 = Input.mousePosition - screenPos;
                float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
                hourHand.transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
                //hourGRAB.transform.eulerAngles = new Vector3(0, 0, angle + angleOffset);
            }
        }
     }
    }
