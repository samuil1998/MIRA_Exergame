using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareVariables : MonoBehaviour {
    private bool pause = false;
    private bool obstacles = true;
    public int result = 0;
    public string difficulty = "";
    private static int dontdest = 0;
    private bool volume = true;
        
    void Awake()
    {
        //sth like singleton pattern - ensures that there is at all times only one Music object and only one Shared variables object
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

    public void switchVolume()
    {
        volume = !volume;

        //this is for the background music
        if (volume == true)
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = 1.0f;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = 0.0f;
        }
    }

    public bool getVolume()
    {
        return volume;
    }
}
