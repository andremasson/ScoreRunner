using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManagerScript : MonoBehaviour {
    
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
       
    
    void Start () {
        GameControllerScript.instance.player = player;
        GameControllerScript.instance.background = background;
        GameControllerScript.instance.objectSpawner = objectSpawner;
        GameControllerScript.instance.startGamePanel = startGamePanel;
        GameControllerScript.instance.gameOverPanel = gameOverPanel;
        GameControllerScript.instance.initialSpeed = gameSpeed;

        GameControllerScript.instance.StartNewGame();
    }
		
}
