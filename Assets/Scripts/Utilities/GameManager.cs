using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static GameState CurrentGameState;

    public static bool Debugging = false;

    static void OnEnable()
    {
        EventBus.Subscribe<GameState>(EventCategory.GameStateChange, GameStateChange);
        //Add listener for when the state of the Toggle changes, and output the state
    }

    static void OnDisable()
    {
        EventBus.Unsubscribe<GameState>(EventCategory.GameStateChange, GameStateChange);
    }

    static void GameStateChange(GameState state)
    {
        CurrentGameState = state;
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void EnableDebug()
    {
        Debugging = true;
    }

    public static void DisableDebug()
    {
        Debugging = false;
    }

}

public class GameStateExample : MonoBehaviour
{
    public void DoThing()
    {
        switch (GameManager.CurrentGameState)
        {
            case GameState.Menu:
                break;
            case GameState.Running:
                break;
            case GameState.Paused:
                break;
        }
    }
}


public enum GameState
{
    Menu,
    Running,
    Paused,
    GameOver,
    Other,
}