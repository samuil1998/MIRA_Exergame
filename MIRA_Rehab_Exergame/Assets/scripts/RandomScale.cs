using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour {
    private float random;
	// Use this for initialization
	void Start () {
        random =  Random.Range(0, 10);
        Debug.Log(random);

        transform.localScale += new Vector3(random / 150, random / 150, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
