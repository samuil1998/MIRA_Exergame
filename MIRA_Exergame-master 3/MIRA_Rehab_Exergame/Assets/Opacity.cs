using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opacity : MonoBehaviour {

    public float opacity = 0.5f;

	// Use this for initialization
	void Start () {
        GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, opacity);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
