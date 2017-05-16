using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayScript : MonoBehaviour {

    [SerializeField]
    public int health;

    [SerializeField]
    private GameObject[] hearts;

    public void SetHealth(int health)
    {
        this.health = health;

        foreach(GameObject heart in hearts)
        {
            heart.SetActive(false);
        }

        for (int i = 0; i < health; i++)
        {
            hearts[i].SetActive(true);
        }
    }
}
