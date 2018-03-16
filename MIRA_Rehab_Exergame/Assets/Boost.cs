using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour {
    private GameObject[] enemies;
    private GameObject track;
    private GameObject[] trees;
    private GameObject tspawner;
    private GameObject cspawner;
    private TreeSpawner treeSpawner;
    private carspawner carSpawner;
    public float boostSpeed = 12;

    private bool boostMode = false;

    void Start () {
        //find all the enemy cars and store them in an array to destroy them later
        track = GameObject.FindGameObjectWithTag("Track");
        tspawner = GameObject.FindGameObjectWithTag("TreeSpawner");
        cspawner = GameObject.FindGameObjectWithTag("CarSpawner");
        treeSpawner = tspawner.GetComponent<TreeSpawner>();
        carSpawner = cspawner.GetComponent<carspawner>();
	}
	
	// Update is called once per frame
	void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemycar");
        trees = GameObject.FindGameObjectsWithTag("Tree");

        //enter boost
        if (Input.GetKeyDown("space") && boostMode == false)
        {
            //destroy enemies
            Debug.Log("length is " + enemies.Length);
            for (int i = 0; i < enemies.Length; i++)
            {

                Destroy(enemies[i]);
            }

            //accelerate track
            trackmove move = track.GetComponent<trackmove>();
            move.speed = boostSpeed / 6;

            //accelerate existing trees
            for (int i = 0; i < trees.Length; i++)
            {
                trees[i].GetComponent<EnemycarMove>().speed = boostSpeed;
            }

            //accelerate future prefabs by accessing the TreeSpawner
            treeSpawner.UpdateSpeed(boostSpeed);
            //and make the spawner spawn them more often to compensate for the high speed
            treeSpawner.delaytimer = 0.3f;

            //set the boost mode in carspawner to true to stop spawning cars 
            carSpawner.SetBoost(true);

            boostMode = true;
        }

        //escape boost 
        else if (Input.GetKeyDown("space") && boostMode == true)
        {
            Debug.Log("Cancelling boost");

            //get the track speed back to normal
            trackmove move = track.GetComponent<trackmove>();
            move.speed = 0.5f;
            //current trees back to normal
            for (int i = 0; i < trees.Length; i++)
            {
                trees[i].GetComponent<EnemycarMove>().speed = 5.5f;
            }
            //and newly spawned trees too
            treeSpawner.UpdateSpeed(5.5f);
            treeSpawner.delaytimer = 0.6f;
            //turn boost mode off to allow enemy cars being spawned again
            carSpawner.SetBoost(true);

            boostMode = false;
        }
	}
}
