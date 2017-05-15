using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackgroundScript: MonoBehaviour {
    
    [SerializeField]
    private float speed;
    
    private Material material;

    private void Awake()
    {
        MeshRenderer background = GetComponent<MeshRenderer>();
        material = background.material;
    }

    void Update()
    {
        if (GameControllerScript.instance.gameOver) return;

        Vector2 offset = material.mainTextureOffset;
        offset.y = offset.y - (speed * Time.deltaTime);
        material.mainTextureOffset = offset;        
    }

}
