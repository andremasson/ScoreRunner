using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

    [SerializeField]
    private GameObject pausePanel;

    private bool paused;
    
    public void Pause()
    {        
        paused = !paused;
        DebugX.Log("PAUSA: " + paused);
        gameObject.SetActive(paused);
        GameControllerScript.instance.Pause();
    }
    
    public void Restart()
    {
        paused = !paused;
        DebugX.Log("RESTART");
        gameObject.SetActive(paused);
        GameControllerScript.instance.Pause();
        GameControllerScript.instance.StartNewGame();
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
