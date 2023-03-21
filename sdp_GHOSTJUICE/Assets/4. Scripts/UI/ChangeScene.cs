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
       // GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
        SceneManager.LoadScene(2);
        //replace with intro sequence later
    }

    public void LoadIntro()
    {
        // GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
        SceneManager.LoadScene(1);
        //replace with intro sequence later
    }
    public void backToStart()
    {
        //GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
        SceneManager.LoadScene(0);
        //replace with intro sequence later
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        //throw new System.NotImplementedException();
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
