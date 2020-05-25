using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] GameObject title = null;

    private void Awake()
    {
        GameManager.OnStartGame += OnStartGame;
        //GameManager.OnStopGame += OnStopGame;
    }

    private void OnStartGame(object sender, StartGameEventArgs e)
    {
        if (title != null)
            title.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
