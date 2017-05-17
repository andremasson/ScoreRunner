using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartPanelScript : MonoBehaviour {

    [SerializeField]
    private GameObject getReady;

    [SerializeField]
    private Animator count;

    [SerializeField]
    private GameObject go;
    
    public void DisplayCountdown()
    {
        gameObject.SetActive(true);
        count.StopPlayback();
        StartCoroutine(GetReady());
    }

    IEnumerator GetReady()
    {
        getReady.SetActive(true);
        count.gameObject.SetActive(false);
        go.SetActive(false);
        yield return new WaitForSeconds(1);
        StartCoroutine(Count());
    }

    IEnumerator Count()
    {
        getReady.SetActive(false);
        count.gameObject.SetActive(true);
        count.Play("Count", -1, 0f);
        yield return new WaitForSeconds(3);
        StartCoroutine(Go());
    }

    IEnumerator Go()
    {
        count.gameObject.SetActive(false);
        go.SetActive(true);
        yield return new WaitForSeconds(1);
        go.SetActive(false);
        gameObject.SetActive(false);
    }
}
