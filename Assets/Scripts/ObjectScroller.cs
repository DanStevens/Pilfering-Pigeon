using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEditor;
using UnityEngine;


/// <summary>
/// Scrolls 2D objects horizontally
/// </summary>
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
                    bool speedIsNeg = o.velocity.x < 0;
                    float xPos = o.transform.position.x;
                    float xSize = collider.size.x;
                    if (speedIsNeg && (xPos < -xSize) || (xPos > xSize))
                        RepositionBackground(o, collider.size.x);
                }
            }
        }
    }

    private static void RepositionBackground(Rigidbody2D o, float horizontalLength)
    {
        Vector2 groundOffset = new Vector2(horizontalLength * 2f, 0);
        o.transform.position = (Vector2)o.transform.position + (groundOffset * (o.velocity.x < 0 ? 1 : -1));
    }

    public void SetScrollSpeed(float speed)
    {
        foreach (Rigidbody2D rigidbody in objects)
            rigidbody.velocity = new Vector2(speed, 0);
    }
}
