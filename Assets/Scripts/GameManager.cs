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
    bool isGameActive = false;

    public static bool IsGameActive => Instance.isGameActive;

    public static float GlobalScollSpeed
    {
        get => Instance.globalScrollSpeed;
        set => Instance.globalScrollSpeed = value;
    }

    public static event EventHandler<StartGameEventArgs> OnStartGame;
    public static event EventHandler OnStopGame;

    public static void StartGame(float minSpawnInterval, float maxSpawnInterval)
    {
        Instance.isGameActive = true;
        OnStartGame?.Invoke(Instance, new StartGameEventArgs(minSpawnInterval, maxSpawnInterval));
    }

    public static void StopGame()
    {
        Instance.isGameActive = false;
        OnStopGame?.Invoke(Instance, EventArgs.Empty);
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
        //if (Input.anyKeyDown)
        //    StartGame(1f);
    }

    public static void IncrementScore()
    {
        Instance.score++;
        Instance.scoreText.text = $"Score: {Instance.score}";
    }

}

public class StartGameEventArgs : EventArgs
{
    public StartGameEventArgs(float minSpawnInterval, float maxSpawnInterval)
    {
        MinSpawnInterval = minSpawnInterval;
        MaxSpawnInterval = maxSpawnInterval;
    }

    public float MinSpawnInterval { get; set; }
    public float MaxSpawnInterval { get; set; }
}