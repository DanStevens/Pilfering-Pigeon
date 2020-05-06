using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class ObjectScroller : MonoBehaviour
{
    [SerializeField] Rigidbody2D[] objects;

    // Update is called once per frame
    public void SetScrollSpeed(float speed)
    {
        foreach (Rigidbody2D rigidbody in objects)
            rigidbody.velocity = new Vector2(speed, 0);
    }
}
