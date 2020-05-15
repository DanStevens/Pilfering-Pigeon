using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
using UnityEngine.UIElements;

public class Collectable : MonoBehaviour
{
    private ObjectScroller scroller;

    private void Awake()
    {
        scroller = gameObject.AddComponent<ObjectScroller>();
        scroller.objects = new[] { GetComponent<Rigidbody2D>() };
    }

    private void OnEnable()
    {
        scroller.SetScrollSpeed(GameManager.Instance.GlobalScollSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            GameManager.Instance.IncrementScore();
            PoolManager.ReleaseObject(gameObject);
            //gameObject.SetActive(false);
        }
    }

    
}
