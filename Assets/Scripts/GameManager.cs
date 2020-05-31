using ObjectPooling;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : Singleton<GameManager>
{

    [Tooltip("The speed at which the ground scrolls. Negative values scroll to the left; positive to the right")]
    [SerializeField] float globalScrollSpeed = -2f;

    [SerializeField] ObjectScroller[] objectScrollers = { };
    [SerializeField] Text scoreText = null;

    int score = 0;
    GameState gameState = GameState.Title;

    public static bool IsGameActive => GameState == GameState.Running;
    public static GameState GameState => Instance.gameState;

    public static float GlobalScollSpeed
    {
        get => Instance.globalScrollSpeed;
        set => Instance.globalScrollSpeed = value;
    }

    public static event EventHandler<StartGameEventArgs> OnStartGame;
    public static event EventHandler GameStateChanged;

    public static void StartGame(DifficultyParameters difficultyParameters)
    {
        Instance.gameState = GameState.Running;
        OnStartGame?.Invoke(Instance, new StartGameEventArgs(difficultyParameters));
        GameStateChanged?.Invoke(Instance, EventArgs.Empty);
    }

    public static void GameOver()
    {
        Instance.gameState = GameState.GameOver;
        GameStateChanged?.Invoke(Instance, EventArgs.Empty);
    }

    public static void RestartGame()
    {
        Instance.score = 0;
        Instance.scoreText.text = $"Score: {Instance.score}";
        Instance.gameState = GameState.Title;
        GameStateChanged?.Invoke(Instance, EventArgs.Empty);
    }

    public static void PauseGame()
    {
        Instance.gameState = GameState.Paused;
        GameStateChanged?.Invoke(Instance, EventArgs.Empty);
    }

    public static void IncrementScore()
    {
        Instance.score++;
        Instance.scoreText.text = $"Score: {Instance.score}";
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var scroller in objectScrollers) {
            Assert.IsNotNull(scroller);
            scroller.SetScrollSpeed(globalScrollSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Instance.gameState == GameState.GameOver && Input.GetKey(KeyCode.Mouse0))
            RestartGame();
    }

}

public class StartGameEventArgs : EventArgs
{
    public StartGameEventArgs(DifficultyParameters difficultyParameters)
    {
        DifficultyParameters = difficultyParameters;
    }

    public DifficultyParameters DifficultyParameters { get; set; }
}

public enum GameState
{
    Title, Running, Paused, GameOver
}