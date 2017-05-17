using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuControllerScript : MonoBehaviour {

    [SerializeField]
    private Text highscoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    private void OnEnable()
    {
        DebugX.Log("CARREGOU algo");
        highscoreText.text = HighscoreScript.GetHighscore().ToString();
    }
}
