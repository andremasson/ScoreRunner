using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour {
    
    private bool showMenu;
    
    public void Pause()
    {        
        showMenu = true;
        DebugX.Log("PAUSA: " + showMenu);
        gameObject.SetActive(showMenu);
        GameControllerScript.instance.Pause();
    }

    public void Resume()
    {
        showMenu = false;
        DebugX.Log("PAUSA: " + showMenu);
        gameObject.SetActive(showMenu);
        GameControllerScript.instance.Unpause();
    }
    
    public void Restart()
    {
        showMenu = false;
        DebugX.Log("RESTART");
        gameObject.SetActive(showMenu);
        GameControllerScript.instance.Unpause();
        GameControllerScript.instance.StartNewGame();
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }

    /*
    private void FadeAnimation()
    {
        if (paused)
        {
            gameObject.SetActive(paused);
            DebugX.Log("FADE IN");
            GetComponent<Animator>().Play("PauseFadeinAnimation", -1, 0f);
        } else
        {
            gameObject.SetActive(paused);
            DebugX.Log("FADE OUT");
            GetComponent<Animator>().Play("PauseFadeoutAnimation", -1, 0f);
        }
    }
    */
}
