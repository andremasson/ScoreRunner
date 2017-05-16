using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectScript : MonoBehaviour {

    [SerializeField]
    public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {
        if (GameControllerScript.instance.gameOver) return;

        Vector2 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        transform.position = temp;
	}
}
