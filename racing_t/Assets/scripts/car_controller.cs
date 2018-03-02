using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_controller : MonoBehaviour {

	public float carspeed;
//	public float maxPos = 1.5f;

	Vector3 position;

	// Use this for initialization
	void Start () {
		position = transform.position; //gets current posotion 
	}
	
	// Update is called once per frame
	void Update () {

		position.x += Input.GetAxis ("Horizontal") * carspeed * Time.deltaTime;
		position.x =  Mathf.Clamp (position.x, -1.9f, 2.0f);
		transform.position = position;

	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag == "Enemycar") {
			Destroy (col.gameObject);
		}
	}
}


//public class car_controller : MonoBehaviour
//{
//	public float moveSpeed;
//	// Use this for initialization
//	void Start () 
//	{
//
//	}
//
//	// Update is called once per frame
//	void Update ()
//	{
//		//Moves Forward and back along z axis                           //Up/Down
//		transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical")* moveSpeed);
//		//Moves Left and right along x Axis                               //Left/Right
//		transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal")* moveSpeed);      
//	}
//}