using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareVariables : MonoBehaviour {
    private bool pause = false;
    private bool obstacles = true;
    public int result = 0;
    public string difficulty = "";

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public bool getPause()
    {
        return pause;
    }

    public void setPause(bool b)
    {
        pause = b;
    }


    public bool getObstacles()
    {
        return obstacles;
    }

    public void setObstacles(bool b)
    {
        obstacles = b;
    }

    public void resetObstacles()
    {
        obstacles = !obstacles;
        //switch to the other state
    }
}
