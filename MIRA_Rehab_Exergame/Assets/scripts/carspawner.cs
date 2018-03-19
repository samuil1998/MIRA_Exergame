using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carspawner : MonoBehaviour {
    private Camera cam;
    private float cameraHeight;
    private float cameraWidth;
	public GameObject[] cars;
	private int carNo;
	public float delaytimer = 1f;
	private float timer;
    bool pause = false;
    bool obstacles = true;
    bool boostMode = false;
    GameObject shared;
    ShareVariables sv;

	// Use this for initialization
	void Start () {
		timer = delaytimer;
        cam = Camera.main;
        cameraHeight = 2f * cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;

        shared = GameObject.FindGameObjectWithTag("SharedVariables");
        sv = shared.GetComponent<ShareVariables>();

		
	}
	
	// Update is called once per frame
	void Update () {
        pause = sv.getPause();
        obstacles = sv.getObstacles();
        if (pause == false && obstacles == true && boostMode == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Vector3 carPos = new Vector3(Random.Range(-cameraWidth / 2 + 2.5f, cameraWidth / 2 - 2.5f), transform.position.y, 0); //get random position in the area above the camera
                // 2.5f keeps the randomly spawned cars off the grass
                carNo = (int)Random.Range(0, 4); //get random car from the prefabs
                Instantiate(cars[carNo], carPos, transform.rotation); //instantiate it with the random position
                timer = delaytimer; //reset the timer
            }
        }
			
	}

    public void SetBoost(bool b)
    {
        boostMode = b;
    }
}
