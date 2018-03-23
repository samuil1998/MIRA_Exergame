using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomScale : MonoBehaviour {
    private float random;
    public float ratio = 150;
	// Use this for initialization
	void Start () {
        random =  Random.Range(0, 10);

        transform.localScale += new Vector3(random / ratio, random / ratio, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
