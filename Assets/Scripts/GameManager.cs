using ObjectPooling;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    
    [Tooltip("The speed at which the ground scrolls. Negative values scroll to the left; positive to the right")]
    [SerializeField] float globalScrollSpeed = -2f;

    [SerializeField] ObjectScroller[] objectScrollers;
    [SerializeField] Text scoreText;

    [SerializeField] GameObject collectablePrefab;
    [SerializeField] Transform spawnPoint;

    public int score = 0;

    public float GlobalScollSpeed => globalScrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var scroller in objectScrollers) {
            Assert.IsNotNull(scroller);
            scroller.SetScrollSpeed(globalScrollSpeed);
        }

        InvokeRepeating(nameof(SpawnCollectable), 0f, 1f);
        //SpawnCollectable();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

    void SpawnCollectable()
    {
        PoolManager.SpawnObject(collectablePrefab, spawnPoint.transform.position, collectablePrefab.transform.rotation);
    }
}
