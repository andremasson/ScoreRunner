using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour {

    public static GameControllerScript instance;

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
            gameOver = false;
            paused = false;
        }        
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
}
