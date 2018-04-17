using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour {

    public float boundary = -5f;
    Vector2 pos;
	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        pos = transform.position;
        if (pos.y < boundary)
        {
            Destroy(gameObject);
        }
		
	}
}
