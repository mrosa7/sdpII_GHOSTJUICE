using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;
    public inGameDialogManager inGameDialogManager;

    public GameObject upstairsNav;
    public GameObject hallwayForwardNav;
    public GameObject bedroomUpNav;

    public bool objective1_matches = false;
    public bool objective1_paper = false;
    public bool canClickObj = true;

    void Awake()
    {
        Instance = this; // This instance is public avaliable everywhere
    }

    private void Start()
    {
        //DontDestroyOnLoad(this.gameObject); // prevents it from being lost during scene change
        UpdateGameState(GameState.StartGame); // init game state on startscreen
    }
    
    // runs functions based on what game state it changes too?
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            //base Game. No puzzles solved. 
            case GameState.StartGame:
                //inGameDialogManager.GhostState = "inital";
                break;

            case GameState.FirstPuzzleComplete:
                // reload some assets, make things avalible.
                // init some dialogue?
                Debug.Log("GAME STATE HAS BEEN CHANGED");
                upstairsNav.SetActive(true);
                break;

            case GameState.SecondPuzzleComplete:
                Debug.Log("GAME STATE HAS BEEN CHANGED");
                hallwayForwardNav.SetActive(true);
                //GameObject door = GameObject.Find("Interactable - Door");
                //door.SetActive(false);
                break;
            case GameState.ThirdPuzzleComplete:
                bedroomUpNav.SetActive(true);
                GameObject atticDoor = GameObject.Find("Interactable - Attic Door");
                atticDoor.SetActive(false);
                break;
            case GameState.EndGameSeq:
                // ????????
                break;
            case GameState.ShowEndScreen:
                //???? Destroy stuff??
                break;
            case GameState.RESET:
                //DESTROY EVERYTHING IN DO NOT DESTROY ON LOAD
                // re instanciate anything that needs to be
                break;

            default:
                break;
        }

        OnGameStateChanged?.Invoke(newState);

    }

}

public enum GameState
{
    StartGame,
    FirstPuzzleComplete,
    SecondPuzzleComplete,
    ThirdPuzzleComplete,
    EndGameSeq,
    ShowEndScreen,
    RESET

}