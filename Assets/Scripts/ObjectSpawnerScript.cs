using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnerScript : MonoBehaviour {

    [SerializeField]
    private GameObject[] obstacles;

    [SerializeField]
    private float defaultSpeed;

    [SerializeField]
    public float spawnSpeed;
    
    private int minX, maxX;
    private float timer;
    private int lastX, randomPosition;

    private void Awake()
    {
        randomPosition = lastX = 0;
        timer = 0;
        minX = -2;
        maxX = 3;
    }
    
    private void SpawnObstacle()
    {
        GameObject block = Instantiate<GameObject>(obstacles[0]);
        Vector2 temp = transform.position;
        while(randomPosition == lastX)
        {
            randomPosition = Random.Range(minX, maxX);
        }
        temp.x = (float)randomPosition; 
        lastX = randomPosition;
        block.transform.position = temp;
        ((MovingBlockScript)block.GetComponent<MovingBlockScript>()).speed = defaultSpeed;
    }

    private void Update()
    {
        if (GameControllerScript.instance.gameOver) return;

        timer += Time.deltaTime;
        if (timer > spawnSpeed)
        {
            SpawnObstacle();
            timer = 0;
        }
    }
}
