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

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    public float gameSpeed;

    public bool gameOver;
    public int health;
    public int points;
    public bool gamePaused;

    private float initialSpeed;
    private float playTime;
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
            initialSpeed = gameSpeed;
            playTime = 0f;
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
            player.GetComponent<PlayerScript>().playerCanMove = false;
            gameOverPanel.SetActive(true);
        }

        if (Input.GetButtonDown("Menu"))
        {
            Pause();
        }

        if (points >= 5)
        {
            gameSpeed = 5f;
        }
    }

    public void Pause()
    {   
        if (gamePaused)
        {
            Time.timeScale = 1f;
            gamePaused = false;
        } else
        {
            Time.timeScale = 0f;
            gamePaused = true;
        }
    }

    public void Unpause()
    {
        Time.timeScale = 1f;
        gamePaused = false;
    }

    public void StartNewGame()
    {
        gameOver = false;
        paused = false;
        health = 3;
        points = 0;
        gameSpeed = initialSpeed;
        playTime = 0f;
        ObjectPoolScript.instance.MakePoolInactive();
        background.GetComponent<ScrollBackgroundScript>().ResetBackground();
        player.GetComponent<PlayerScript>().ResetPlayer();
        objectSpawner.GetComponent<ObjectSpawnerScript>().ResetSpawner();
        startGamePanel.SetActive(true);
        startGamePanel.GetComponent<GameStartPanelScript>().DisplayCountdown();
    }
}
