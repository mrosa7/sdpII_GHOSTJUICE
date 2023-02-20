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

    void Awake()
    {
        Instance = this; // This instance is public avaliable everywhere
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject); // prevents it from being lost during scene change
        UpdateGameState(GameState.StartScreen); // init game state on startscreen
    }
    
    // runs functions based on what game state it changes too?
    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.StartGame:
                inGameDialogManager.GhostState = "inital";
                break;

            case GameState.FirstPuzzleComplete:
                // reload some assets, make things avalible.
                // init some dialogue?
                Debug.Log("GAME STATE HAS BEEN CHANGED");
                inGameDialogManager.GhostState = "postPuzzle1";
                break;

            case GameState.SecondPuzzleComplete:

                break;
            case GameState.ThirdPuzzleComplete:

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
    StartScreen,
    StartGame,
    FirstPuzzleComplete,
    SecondPuzzleComplete,
    ThirdPuzzleComplete,
    EndGameSeq,
    ShowEndScreen,
    RESET

}