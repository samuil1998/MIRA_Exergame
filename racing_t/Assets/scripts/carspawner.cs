using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawner : MonoBehaviour {

	public GameObject[] cars;
	private int carNo;
	public float delaytimer = 1f;
	private float timer;

	// Use this for initialization
	void Start () {
		timer = delaytimer;
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		if (timer <= 0) 
		{
			Vector2 carPos = new Vector2 (Random.Range (0f, 1.94f), transform.position.y); //get random position in the area above the camera
            carNo = (int) Random.Range (0, 4); //get random car from the prefabs
			Instantiate (cars[carNo], carPos, transform.rotation); //instantiate it with the random position
			timer = delaytimer; //reset the timer
		}
	}
}
