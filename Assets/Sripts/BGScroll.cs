using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroll : MonoBehaviour
{ 
    public float speed;
    
    private float offSet;

    private void Update()
    {
        offSet += Time.deltaTime * speed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(offSet, 0);

        if (GameManager.manager.end == true)
            speed = 0;
    }
}
