using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2_HandCollision : MonoBehaviour
{
    public GameObject targetCollision;
    public bool isSolved;
    // Start is called before the first frame update
    void Start()
    {
        isSolved = false;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        //Debug.Log("IM HITTING SOMETHING");
        if (collision.gameObject == targetCollision)
        {
            Debug.Log("I've been solved!!!");
            isSolved = true;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == targetCollision)
        {
            isSolved = false;
        }
    }
}
