using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjectScript : MonoBehaviour {

    [SerializeField]
    private GameObject objectToFollow;

    [SerializeField]
    private bool followX, followY;
    
    private Vector3 differenceInPosition;

	void Awake () {
        differenceInPosition = new Vector2();
        differenceInPosition.x = transform.position.x - objectToFollow.transform.position.x;
        differenceInPosition.y = transform.position.y - objectToFollow.transform.position.y;
        followX = followY = false;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = transform.position;
        if (followX)
            temp.x = objectToFollow.transform.position.x + differenceInPosition.x;
        if (followY)
            temp.y = objectToFollow.transform.position.y + differenceInPosition.y;
        transform.position = temp;
    }
}
