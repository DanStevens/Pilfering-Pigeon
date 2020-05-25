﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

public class CollectableManager : MonoBehaviour
{
    [SerializeField] StartGameEventArgs gameArgs = null;
    [SerializeField] GameObject collectablePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float offset = 3.5f;
    [SerializeField] int poolSizeFactor = 6;

    private Coroutine spawner = null;

    private void Awake()
    {
        GameManager.OnStartGame += OnStartGame;
        GameManager.OnStopGame += OnStopGame;
    }

    private void OnStopGame(object sender, System.EventArgs e)
    {
        if (spawner != null)
            StopCoroutine(spawner);
    }

    private void OnStartGame(object sender, StartGameEventArgs e)
    {
        gameArgs = e;
        PoolManager.WarmPool(collectablePrefab, CalculatePoolSize(e.MinSpawnInterval));
        //InvokeRepeating(nameof(SpawnCollectable), 0f, e.SpawnRate);
        spawner = StartCoroutine(nameof(SpawnCollectable));
    }

    private int CalculatePoolSize(float interval)
    {
        return (int)System.Math.Ceiling(poolSizeFactor / interval);
    }

    // Start is called before the first frame update
    void Start()
    {
        //SpawnCollectable();
    }

    IEnumerator SpawnCollectable()
    {
        for (;;) {
            if (GameManager.IsGameActive) {
                PoolManager.SpawnObject(collectablePrefab, GetRandomPosition(),
                    collectablePrefab.transform.rotation);
            }
            yield return new WaitForSeconds(GetRandomSpawnInterval());
        }

    }

    private float GetRandomSpawnInterval()
    {
        return Random.Range(gameArgs.MinSpawnInterval, gameArgs.MaxSpawnInterval);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector2(x: spawnPoint.transform.position.x,
            y: spawnPoint.transform.position.y + Random.Range(-offset, offset));
    }
}
