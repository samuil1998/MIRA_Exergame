using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemycarMove : MonoBehaviour 
{
    GameObject shared;
    ShareVariables sv;
    bool pause = false;

	public float speed = 3f;


	// Use this for initialization
	void Start () 
	{
        shared = GameObject.FindGameObjectWithTag("SharedVariables");
        sv = shared.GetComponent<ShareVariables>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        pause = sv.getPause();
        if (pause == false)
        {
            transform.Translate(new Vector3(0, 1, 0) * speed * Time.deltaTime);
        }
	}
		
}
