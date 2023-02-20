using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private void Awake()
    {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }
    public void LoadGame()
    {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
        SceneManager.LoadScene(1);
        

        //replace with intro sequence later
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        throw new System.NotImplementedException();
    }
}