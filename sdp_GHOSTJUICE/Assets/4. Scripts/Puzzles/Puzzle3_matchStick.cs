using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle3_matchStick : MonoBehaviour
{
    Vector3 startPos;
    public float speed;
    public GameObject lBound;
    public GameObject hBound;

    GameObject selectedObject;
    Vector3 offset;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
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
        if (selectedObject)
        {
            selectedObject.transform.position = new Vector3(startPos.x,mousePosition.y + offset.y);
            if (selectedObject.transform.position.y <= lBound.transform.position.y)
            {
                selectedObject.transform.position = new Vector3(startPos.x, lBound.transform.position.y);
            }
            else if(selectedObject.transform.position.y >= hBound.transform.position.y)
            {
                selectedObject.transform.position = new Vector3(startPos.x, hBound.transform.position.y);
            }

        }
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            var step = speed * Time.deltaTime; // calculate distance to move
            selectedObject.transform.position = Vector3.MoveTowards(selectedObject.transform.position, startPos, step);
            if (Vector3.Distance(transform.position, startPos) < 0.001f)
            {
                // Swap the position of the cylinder.
                selectedObject.transform.position = startPos;

            }

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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "MatchBox")
        {
            if (timer <= 0.3f)
            {
                Debug.Log("PASS");
            }
            else
            {
                Debug.Log("Fail");
            }
            timer = 0f;
        }
    }
}
