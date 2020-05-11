using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    [Tooltip("The speed at which the ground scrolls. Negative values scroll to the left; positive to the right")]
    [SerializeField] float groundScollSpeed = -2f;

    private ObjectScroller objectScroller;

    // Start is called before the first frame update
    void Start()
    {
        objectScroller = GetComponent<ObjectScroller>();
        objectScroller.SetScrollSpeed(groundScollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
