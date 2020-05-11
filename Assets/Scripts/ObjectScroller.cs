using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ObjectScroller : MonoBehaviour
{
    [SerializeField] Rigidbody2D[] objects = new Rigidbody2D[] { };

    [Tooltip("When true, objects are set back to their original position so that they can scroll indefinintely for a given area. " + 
        "Useful to infininate scrolling backgrounds ")]
    [SerializeField] bool carouselObjects = false;

    void Update()
    {
        if (carouselObjects) {
            foreach (var o in objects) {
                if (o.TryGetComponent(out BoxCollider2D collider)) {
                    if (o.transform.position.x < -collider.size.x)
                        RepositionBackground(o, collider.size.x);
                }
            }
        }
    }

    private static void RepositionBackground(Rigidbody2D o, float horizontalLength)
    {
        Vector2 groundOffset = new Vector2(horizontalLength * 2f, 0);
        o.transform.position = (Vector2)o.transform.position + groundOffset;
    }

    public void SetScrollSpeed(float speed)
    {
        foreach (Rigidbody2D rigidbody in objects)
            rigidbody.velocity = new Vector2(speed, 0);
    }
}
