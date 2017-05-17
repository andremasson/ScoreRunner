using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolScript : MonoBehaviour {

    public static ObjectPoolScript instance;

    [SerializeField]
    public GameObject[] obstaclesPrefabs;

    [SerializeField]
    public GameObject[] collectablesPrefabs;

    [SerializeField]
    private int obstaclePoolSize;

    [SerializeField]
    private int collectablesPoolSize;

    private List<GameObject> obstaclesPool;
    private List<GameObject> collectablesPool;

    void Start () {
        instance = this;
        obstaclesPool = new List<GameObject>();
        collectablesPool = new List<GameObject>();

        foreach(GameObject obj in obstaclesPrefabs)
        {
            for(int i = 0; i < obstaclePoolSize; i++)
            {
                GameObject newObject = Instantiate<GameObject>(obj);
                newObject.SetActive(false);
                obstaclesPool.Add(newObject);
            }
        }

        foreach (GameObject obj in collectablesPrefabs)
        {
            for (int i = 0; i < collectablesPoolSize; i++)
            {
                GameObject newObject = Instantiate<GameObject>(obj);
                newObject.SetActive(false);
                collectablesPool.Add(newObject);
            }
        }
        DebugX.Log("E ae?");
    }		

    public GameObject GetObstacle()
    {
        foreach(GameObject obj in obstaclesPool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }

    public GameObject GetCollectable()
    {
        foreach (GameObject obj in collectablesPool)
        {
            if (!obj.activeSelf)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return null;
    }

    public void MakePoolInactive()
    {
        foreach (GameObject obj in obstaclesPool)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in collectablesPool)
        {
            obj.SetActive(false);
        }
    }
}
