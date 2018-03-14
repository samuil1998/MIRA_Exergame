using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class creatingcoins : MonoBehaviour 
{

	public float speed = 5f;

	// Use this for initialization
	void Start () 
	{

	}

	// Update is called once per frame
	void Update () 
	{
		transform.Translate (new Vector3 (0, 1, 0) * speed * Time.deltaTime);

        if (transform.position.y < -15f)
        {
            
            //Destroy(gameObject);
        }
	}

}
