using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackgroundScript: MonoBehaviour {
        
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
        offset.y = offset.y - ((GameControllerScript.instance.gameSpeed+1f) * Time.deltaTime);
        offset.y = offset.y - GameControllerScript.instance.gameSpeed ;
        material.mainTextureOffset = offset;
    }

    public void ResetBackground()
    {
        Vector2 offset = material.mainTextureOffset;
        offset.y = 0;
        material.mainTextureOffset = offset;
    }
}
