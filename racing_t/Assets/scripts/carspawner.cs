using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawner : MonoBehaviour {

	public GameObject[] cars;
	private int carNo;
	public float delaytimer = 1f;
	private float timer;
	public float left_limit;
	public float right_limit;

	// Use this for initialization
	void Start () {
		timer = delaytimer;
	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		if (timer <= 0) 
		{
			Vector2 carPos = new Vector2 (Random.Range (left_limit, right_limit), transform.position.y); //get random position in the area above the camera
            carNo = (int) Random.Range (0, 4); //get random car from the prefabs
			Instantiate (cars[carNo], carPos, transform.rotation); //instantiate it with the random position
			timer = delaytimer; //reset the timer
		}
	}
}
