using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PilferingPigeon
{

    [CreateAssetMenu]
    public class DifficultyParameters : ScriptableObject
    {
        [Range(0.01f, 60f)]
        [SerializeField] float minSpawnInterval = 1f;
        [Range(0.01f, 60f)]
        [SerializeField] float maxSpawnInterval = 2f;

        public float MinSpawnInterval => minSpawnInterval;
        public float MaxSpawnInterval => maxSpawnInterval;
    }

}