using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayerController : MonoBehaviour
{
    [Header("Flight parameters")]
    [SerializeField, Range(0, 100f)] float idleDrag = 10f;
    [SerializeField, Range(0, 100f)] float diveDrag = 0f;
    [SerializeField, Range(100, 1000f)] float upForce = 400f;

    public string Greeting { get; set; } = "Hello";

    private Rigidbody2D rigidBody;
    private PlayerInputLayer playerInput;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInputLayer>();
    }

    // Called one per frame
    private void Update()
    {
        // Prevent the bird from diving and flapping up in the same frame
        var _ = DiveDown() || FlapUp();
    }

    private bool FlapUp()
    {
        
        if (playerInput.FlapedThisFrame) {
            rigidBody.velocity = Vector2.zero;
            rigidBody.AddForce(new Vector2(0, upForce));
            return true;
        }
        return false;
    }

    private bool DiveDown()
    {
        
        if (playerInput.DivedThisFrame)
            rigidBody.velocity = Vector2.zero;
        
        if (playerInput.IsDiving) {
            rigidBody.drag = diveDrag;
            return true;
        } else {
            rigidBody.drag = idleDrag;
            return false;
        }
    }
}