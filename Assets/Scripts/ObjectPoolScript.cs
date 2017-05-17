using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolScript : MonoBehaviour {

    public static ObjectPoolScript instance;
    
    [SerializeField]
    public GameObject[] objectsPrefabs;
    
    [SerializeField]
    public int poolInitialSize;
    
    private List<GameObject>[] objectsPool;
    
    private void Awake()
    {
        instance = this;

        objectsPool = new List<GameObject>[objectsPrefabs.Length];

        for (int type = 0; type < objectsPrefabs.Length; type++)
        {
            objectsPool[type] = new List<GameObject>();
            for (int i = 0; i < poolInitialSize; i++)
            {
                GameObject newObject = AddToPoolAndReturnObject(type);
                newObject.SetActive(false);
            }
        }
    }

    private GameObject AddToPoolAndReturnObject(int type)
    {
        GameObject newObject = Instantiate<GameObject>(objectsPrefabs[type]);
        objectsPool[type].Add(newObject);
        return newObject;
    }

    public GameObject GetObject(int type)
    {
        foreach (GameObject obj in objectsPool[type])
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }
        return AddToPoolAndReturnObject(type);
    }
    
    public void MakePoolInactive()
    {
        for (int type = 0; type < objectsPrefabs.Length; type++)
        {
            foreach (GameObject obj in objectsPool[type])
            {
                obj.SetActive(false);
            }
        }
    }
}
