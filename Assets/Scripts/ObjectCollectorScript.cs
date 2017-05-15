﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollectorScript : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            // collision.gameObject.SetActive(false);
            Destroy(collision.gameObject);
        }
    }
}
