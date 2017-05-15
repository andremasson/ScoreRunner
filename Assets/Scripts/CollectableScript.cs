using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {

    [SerializeField]
    public int points;

    [SerializeField]
    public float speed;
    
    void Update()
    {
        if (GameControllerScript.instance.gameOver) return;

        Vector2 temp = transform.position;
        temp.y -= speed * Time.deltaTime;
        transform.position = temp;
    }
}

