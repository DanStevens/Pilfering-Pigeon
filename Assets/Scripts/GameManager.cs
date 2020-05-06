using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private ObjectScroller objectScroller;

    // Start is called before the first frame update
    void Start()
    {
        objectScroller = GetComponent<ObjectScroller>();
        objectScroller.SetScrollSpeed(-2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
