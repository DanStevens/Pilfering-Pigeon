using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;

    [Range(0.01f, 60f)]
    [SerializeField] float minspawnInterval = 1f;
    [Range(0.01f, 60f)]
    [SerializeField] float maxSpawnInterval = 2f;

    // Start is called before the first frame update
    void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    void SetDifficulty()
    {
        GameManager.StartGame(minspawnInterval, maxSpawnInterval);
    }
}
