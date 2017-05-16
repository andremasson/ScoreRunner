using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour {

    [SerializeField]
    private GameObject pausePanel;

    private bool paused;

    private void Awake()
    {
        
    }

    public void Pause()
    {        
        paused = !paused;
        DebugX.Log("PAUSA: " + paused);
        gameObject.SetActive(paused);
        GameControllerScript.instance.Pause();
    }
    
}
