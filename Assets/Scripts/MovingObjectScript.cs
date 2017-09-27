using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectScript : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
        if (GameControllerScript.instance.gameOver) return;

        Vector2 temp = transform.position;
        temp.y -= GameControllerScript.instance.gameSpeed * Time.deltaTime;
        //temp.y -= GameControllerScript.instance.gameSpeed;
        transform.position = temp;
	}
}
