using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public static event Action<GameState> OnGameStateChanged;

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
                // honestly i don't think I need to run anything here?
                break;

            case GameState.FirstPuzzleComplete:
                // reload some assets, make things avalible.
                // init some dialogue?
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