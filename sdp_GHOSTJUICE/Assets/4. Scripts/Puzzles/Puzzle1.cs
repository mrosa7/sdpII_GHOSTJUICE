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
    RaycastHit2D hit;
    public GameManager GameManager;
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
            hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if (Vector2.Distance(emptySpace.position, hit.transform.position) <=2.5)
                    {
                    // saves empty space position before changing it.
                    StopAllCoroutines();
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    StartCoroutine(movePiece(hit, lastEmptySpacePosition));
                    emptySpace.position = hit.transform.position;
                    //hit.transform.position = lastEmptySpacePosition;
                    //check if the board is now solved
                    

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
            if (Vector3.Distance(Tiles[i].transform.position, solvedBoard[i]) > 1.0f)
            {
                return false;
            }
           /* if (Tiles[i].transform.position != solvedBoard[i])
            
            {
                return false;
            }*/
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

    IEnumerator movePiece(RaycastHit2D hitLocal, Vector2 lastEmptySpacePosition)
    {
        float timeElapsed = 0;
        Vector3 startPosition = hitLocal.transform.position;
        while (timeElapsed < 0.3)
        {
            hitLocal.transform.position = Vector3.Lerp(startPosition, lastEmptySpacePosition, timeElapsed / 0.3f);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        //emptySpace.position = hit.transform.position;
        hit.transform.position = lastEmptySpacePosition;
        if (checkSolved())
        {
            GameManager.Instance.UpdateGameState(GameState.FirstPuzzleComplete);
            MASTERSCRIPT.Instance.postPuzzleDialogue_1();
            Debug.Log("ALL SOLVED");
        }

        //hit.transform.position = lastEmptySpacePosition;
    }

}
