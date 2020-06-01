using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PilferingPigeon
{

    public class BirdPlayerController : MonoBehaviour
    {
        [SerializeField] FlightParameters flightParameters;

        private Rigidbody2D rigidBody;

        private void Start()
        {
            rigidBody = GetComponent<Rigidbody2D>();
        }

        // Called one per frame
        private void Update()
        {
            if (GameManager.IsGameActive) {
                rigidBody.simulated = true;
                // Prevent the bird from diving and flapping up in the same frame
                var _ = DiveDown() || FlapUp();
            } else {
                rigidBody.simulated = false;
            }
        }

        private bool FlapUp()
        {

            if (Input.GetButtonDown("Jump")) {
                rigidBody.velocity = Vector2.zero;
                rigidBody.AddForce(new Vector2(0, flightParameters.UpForce));
                return true;
            }
            return false;
        }

        private bool DiveDown()
        {

            if (Input.GetButtonDown("Dive"))
                rigidBody.velocity = Vector2.zero;

            if (Input.GetButton("Dive")) {
                rigidBody.drag = flightParameters.DiveDrag;
                return true;
            } else {
                rigidBody.drag = flightParameters.IdleDrag;
                return false;
            }
        }
    }

}