using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puzzle1 : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private GameObject emptySpaceObj;
    [SerializeField] private Transform emptySpace;
    [SerializeField] private List<Vector3> solvedBoard;
    [SerializeField] private List<GameObject> Tiles; 
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;

        // creates the solution before it shuffles. idk why i need to do it like this unity is killing me
        foreach( var x in Tiles)
        {
            solvedBoard.Add(x.transform.position);
        }

        Tiles.Add(emptySpaceObj);
        Shuffle();
    }

    // check if the mouse has been clicked, and what object it hit.
    // Clean up? I hate having stuff in update ;-;
    // On complition, stop update?
    // Disable this class?
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //checks if the mouse click hit any of the tiles
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) <=2)
                    {
                    // saves empty space position before changing it.
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    emptySpace.position = hit.transform.position;
                    //hit.transform.position = Vector3.Lerp(hit.transform.position, lastEmptySpacePosition, 1f); // would need to add stuff to make it smoother, rework logic 
                    hit.transform.position = lastEmptySpacePosition;
                    //check if the board is now solved
                    if (checkSolved())
                    {
                        Debug.Log("ALL SOLVED");
                    }

                }
            }
        }

    }

    // compares the current position of all the tiles to the correct positions
    // returns if they all match
    // why it wont let me check between 2 vector3s is beyond me (its unity's problem)
    private bool checkSolved()
    {
        for (int i = 0; i < Tiles.Count-1; i++)
        {

            Debug.Log(Tiles[i].transform.position) ;
           if(Tiles[i].transform.position != solvedBoard[i])
            
            {
                return false;
            }
        }
        return true;
    }
    
    public void Shuffle()
    {
        for (int i = 0; i < 8; i++)
        {
            if(Tiles[i] != null){
                var lastPos = Tiles[i].transform.position;
                int randomIndex = Random.Range(0, 8);
                Tiles[i].transform.position = Tiles[randomIndex].transform.position;
                Tiles[randomIndex].transform.position = lastPos;
            }
        }
    }
}
