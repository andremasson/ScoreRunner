using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDisplayScript : MonoBehaviour {

    [SerializeField]
    public int health;

    public void SetHealth(int health)
    {
        this.health = health;

        SpriteRenderer thisRenderer = GetComponent<SpriteRenderer>();
        Vector2 size = thisRenderer.size;
        size.x = health;
        thisRenderer.size = size;
    }
}
