using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawner : MonoBehaviour {

	public GameObject[] cars;
	int carNo;
	public float delaytimer = 1f;
	float timer;

	// Use this for initialization
	void Start () {
		timer = delaytimer;
		
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		if (timer <= 5) 
		{
			Vector3 carPos = new Vector3 (Random.Range (-1.88f, 1.94f), transform.position.y, transform.position.z);
			carNo = Random.Range (0, 4);
			Instantiate (cars[carNo], carPos, transform.rotation);
			timer = delaytimer;
		}
			
	}
}


//sa.dfn.akjdsfk.ashdfkj skhfksdghaf kdsfha fhk 