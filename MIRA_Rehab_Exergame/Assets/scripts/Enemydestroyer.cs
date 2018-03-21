using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemydestroyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}
	void OnCollisionEnter2D (Collision2D col)
	{
        if (col.gameObject.tag == "Enemycar" || col.gameObject.tag == "coin" || col.gameObject.tag == "Tree" || col.gameObject.tag == "red_coin" || col.gameObject.tag == "Fuel" ) 
		{
			Destroy (col.gameObject);
		}
	}
}
