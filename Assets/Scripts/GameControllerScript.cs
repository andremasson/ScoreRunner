using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    public static GameControllerScript instance;

    [SerializeField]
    private GameObject player;

    [SerializeField]
    private GameObject background;

    [SerializeField]
    private GameObject objectSpawner;

    [SerializeField]
    private GameObject startGamePanel;

    public bool gameOver;
    public int health;
    public int points;

    private bool paused;

    private void Awake()
    {
        
        if (instance != null)
        {
            Destroy(gameObject);
        } else {
            instance = this;
            DontDestroyOnLoad(gameObject);
            paused = false;
        }        
    }

    private void Start()
    {
        StartNewGame();
    }

    private void Update()
    {
        if (health <= 0)
        {
            gameOver = true;
        }

        if (Input.GetButtonDown("Menu"))
        {
            Pause();
        }
    }

    public void Pause()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            paused = false;
        } else
        {            
            Time.timeScale = 0;
            paused = true;
        }
    }
    
    public void StartNewGame()
    {
        gameOver = false;
        paused = false;
        health = 3;
        points = 0;
        ObjectPoolScript.instance.MakePoolInactive();
        background.GetComponent<ScrollBackgroundScript>().ResetBackground();
        player.GetComponent<PlayerScript>().ResetPlayer();
        objectSpawner.GetComponent<ObjectSpawnerScript>().ResetSpawner();
        startGamePanel.SetActive(true);
        startGamePanel.GetComponent<GameStartPanelScript>().DisplayCountdown();
    }
}
