﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour {

    public enum ObjectType
    {
        WALL,
        COIN
    };

    /*
    [SerializeField]
    public GameObject[] obstacles;

    [SerializeField]
    public GameObject[] collectables;
    */

    [SerializeField]
    private float defaultSpeed;

    [SerializeField]
    public float spawnSpeed;
    
    private int minX, maxX;
    private float timer;
    private int lastObstacleX, lastCollectableX, randomPositionObstacle, randomPositionCollectable;

    private void Awake()
    {
        ResetSpawner();
        minX = -2;
        maxX = 3;
    }
    
    private void SpawnObstacle()
    {
        //GameObject block = Instantiate<GameObject>(obstacles[0]);
        GameObject block = ObjectPoolScript.instance.GetObject((int)ObjectType.WALL);
        Vector2 temp = transform.position;
        while(randomPositionObstacle == lastObstacleX)
        {
            randomPositionObstacle = Random.Range(minX, maxX);
        }
        temp.x = (float)randomPositionObstacle; 
        lastObstacleX = randomPositionObstacle;
        block.transform.position = temp;
    }
    
    IEnumerator SpawnCollectable()
    {
        yield return new WaitForSeconds(spawnSpeed / 2);
        //GameObject coin = Instantiate<GameObject>(collectables[0]);
        GameObject coin = ObjectPoolScript.instance.GetObject((int)ObjectType.COIN);
        Vector2 temp = transform.position;
        while (randomPositionCollectable == lastCollectableX)
        {
            randomPositionCollectable = Random.Range(minX, maxX);
        }
        temp.x = (float)randomPositionCollectable;
        lastCollectableX = randomPositionCollectable;
        coin.transform.position = temp;
    }

    private void Update()
    {
        if (GameControllerScript.instance.gameOver) return;

        timer += Time.deltaTime;
        if (timer > spawnSpeed)
        {
            SpawnObstacle();
            StartCoroutine(SpawnCollectable());
            timer = 0;
        }
    }

    public void ResetSpawner()
    {
        randomPositionObstacle = lastObstacleX = lastCollectableX = 0;
        timer = -1f;
    }
}
