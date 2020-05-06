using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputLayer : MonoBehaviour
{
    [SerializeField]  KeyCode diveKey = KeyCode.DownArrow;
    [SerializeField] KeyCode flapKey = KeyCode.UpArrow;

    public bool FlapedThisFrame { get; private set; }
    public bool DivedThisFrame { get; private set; }
    public bool IsDiving { get; private set; }

    // Update is called once per frame
    void Update()
    {
        FlapedThisFrame = Input.GetKeyDown(flapKey);
        DivedThisFrame = Input.GetKeyDown(diveKey);
        IsDiving = Input.GetKey(diveKey);
    }
}
