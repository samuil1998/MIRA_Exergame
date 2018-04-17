using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trackmove : MonoBehaviour {
    GameObject shared;
    ShareVariables sv;
    bool pause = false;
	public float speed;
	Vector2 offset;

	// Use this for initialization
	void Start () {
        shared = GameObject.FindGameObjectWithTag("SharedVariables");
        sv = shared.GetComponent<ShareVariables>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        pause = sv.getPause();
        if (pause == false)
        {
            offset = new Vector2(0, Time.time * speed);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }
	}
}
