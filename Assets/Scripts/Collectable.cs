using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ObjectPooling;
using UnityEngine.UIElements;

namespace PilferingPigeon
{

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
            scroller.SetScrollSpeed(GameManager.GlobalScollSpeed);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player")) {
                PoolManager.ReleaseObject(gameObject);
                GameManager.IncrementScore();

            } else if (collision.CompareTag("Despawn")) {
                PoolManager.ReleaseObject(gameObject);
                GameManager.GameOver();
            }
        }


    }

}