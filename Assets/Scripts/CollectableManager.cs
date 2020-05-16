using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;

public class CollectableManager : MonoBehaviour
{
    [SerializeField] GameObject collectablePrefab;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float offset = 3.5f;
    [SerializeField] int initialPoolSize = 4;

    // Start is called before the first frame update
    void Start()
    {
        PoolManager.WarmPool(collectablePrefab, initialPoolSize);
        InvokeRepeating(nameof(SpawnCollectable), 0f, 1f);
        //SpawnCollectable();
    }

    void SpawnCollectable()
    {
        PoolManager.SpawnObject(collectablePrefab, GetRandomPosition(),
            collectablePrefab.transform.rotation);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector2(x: spawnPoint.transform.position.x,
            y: spawnPoint.transform.position.y + Random.Range(-offset, offset));
    }
}
