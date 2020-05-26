using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject title = null;
    [SerializeField] GameObject gameOver = null;
    [SerializeField] GameObject paused = null;

    private void Awake()
    {
        GameManager.GameStateChanged += GameStateChanged;
    }

    private void GameStateChanged(object sender, EventArgs e)
    {
        if (title != null)
            title.SetActive(GameManager.GameState == GameState.Title);
        if (gameOver != null)
            gameOver.SetActive(GameManager.GameState == GameState.GameOver);
        if (paused != null)
            paused.SetActive(GameManager.GameState == GameState.Paused);
    }
}
