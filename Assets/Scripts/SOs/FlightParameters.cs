using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PilferingPigeon
{
    [CreateAssetMenu]
    public class FlightParameters : ScriptableObject
    {
        [SerializeField, Range(0, 100f)] float idleDrag = 10f;
        [SerializeField, Range(0, 100f)] float diveDrag = 0f;
        [SerializeField, Range(100, 1000f)] float upForce = 400f;

        public float IdleDrag => idleDrag;
        public float DiveDrag => diveDrag;
        public float UpForce => upForce;
    }

}