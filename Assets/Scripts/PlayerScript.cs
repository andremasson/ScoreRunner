﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
          
    [HideInInspector]
    public bool playerCanMove;

    [SerializeField]
    private float turnSpeed;

    [SerializeField]
    private HealthDisplayScript healthDisplay;

    [SerializeField]
    private Text scoreText;

    private float timer;
    private float max_x, min_x;
    private Vector2 touchOrigin = -Vector2.one;

    private int health;
    private int points;

    // Use this for initialization
    void Start()
    {
        health = 3;
        max_x = 2;
        min_x = -2;
        playerCanMove = true;
        timer = turnSpeed;
        GameControllerScript.instance.health = health;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (playerCanMove)
        {
            int horizontalAxis = (int)Input.GetAxisRaw("Horizontal");

            if (Input.touchCount > 0)
            {
                Touch myTouch = Input.touches[0];
                if (myTouch.phase == TouchPhase.Began)
                {
                    touchOrigin = myTouch.position;
                }
                else if (myTouch.phase == TouchPhase.Ended)
                {
                    Vector2 touchEnd = myTouch.position;
                    horizontalAxis = (int) (touchEnd.x - touchOrigin.x);
                }
            }


            if (horizontalAxis > 0 )
            {
                // Move para direita
                MovePlayer(1);
            }
            else if (horizontalAxis < 0)
            {
                // Move para esquerda
                MovePlayer(-1);
            }
        }
    }
    
    private void MovePlayer(float direction)
    {
        if (timer < turnSpeed) return;

        Vector2 temp = transform.position;
        temp.x += direction;
        if (temp.x > max_x) temp.x = max_x;
        if (temp.x < min_x) temp.x = min_x;
        transform.position = temp;

        timer = 0;
    }

    public void MoveRight()
    {
        MovePlayer(1);
    }

    public void MoveLeft()
    {
        MovePlayer(-1);
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            Debug.Log("Dano!");
            health--;
            healthDisplay.SetHealth(health);
            GameControllerScript.instance.health = health;
        }
        else if (collision.gameObject.tag == "Collectable")
        {
            CollectableScript item = collision.gameObject.GetComponent<CollectableScript>();
            points += item.points;
            GameControllerScript.instance.points = points;
            scoreText.text = points.ToString();
            Destroy(collision.gameObject);
            Debug.Log("Pontos! " + points);
        }
    }
}