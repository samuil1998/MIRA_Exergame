using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

    private static int dontdest = 0;

    void Awake()
    {
        if (dontdest == 0)
        {
            Debug.Log(dontdest);
            DontDestroyOnLoad(gameObject);
            dontdest++;
        }
        else
        {
            Destroy(gameObject);
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
