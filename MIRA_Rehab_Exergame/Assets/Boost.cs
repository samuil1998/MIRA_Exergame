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
    private GameObject coinSpawnerObject;
    private coinSpawner cs; 
    public float boostSpeed = 12;
    private float oldCoinsDelay;

    private GameObject[] snowflakes;
    private GameObject[] tyres;

    public float boostTime = 3.0f;

    void Start () {
        //find all the enemy cars and store them in an array to destroy them later
        track = GameObject.FindGameObjectWithTag("Track");
        tspawner = GameObject.FindGameObjectWithTag("TreeSpawner");
        cspawner = GameObject.FindGameObjectWithTag("CarSpawner");
        coinSpawnerObject = GameObject.FindGameObjectWithTag("CoinSpawner");
       
        if (tspawner != null)
        {
            treeSpawner = tspawner.GetComponent<TreeSpawner>();
        }
        cs = coinSpawnerObject.GetComponent<coinSpawner>();
        carSpawner = cspawner.GetComponent<carspawner>();

    }

    // Update is called once per frame
    void Update () {
        enemies = GameObject.FindGameObjectsWithTag("Enemycar");
        trees = GameObject.FindGameObjectsWithTag("Tree");
        snowflakes = GameObject.FindGameObjectsWithTag("Snowflake");
        tyres = GameObject.FindGameObjectsWithTag("Tyre");

        //enter boost
    }

    public void ActivateBoost()
    {
        StartCoroutine(BoostCoroutine());
    }

    IEnumerator BoostCoroutine()
    {
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
            if (trees[i] != null)
            {
                trees[i].GetComponent<EnemycarMove>().speed = boostSpeed;
            }
        }

        //delete existing tyres
        for (int i = 0; i < tyres.Length; i++)
        {
            if (tyres[i] != null)
            {
                Destroy(tyres[i]);
            }
        }

        //accelerate future prefabs by accessing the TreeSpawner (only if there is a treeSpawner - not all levels have)
        if (treeSpawner != null)
        {
            treeSpawner.UpdateSpeed(boostSpeed);
            //and make the spawner spawn them more often to compensate for the high speed
            treeSpawner.delaytimer = 0.3f;
        }
        oldCoinsDelay = cs.delaytimer;
        cs.delaytimer = 0.25f;

        //set the boost mode in carspawner to true to stop spawning cars 
        carSpawner.SetBoost(true);

        yield return new WaitForSeconds(3);
        //WAIT HERE !!!

        //this is to ensure the array is up-to-date with the actual trees in the game
        enemies = GameObject.FindGameObjectsWithTag("Enemycar");
        trees = GameObject.FindGameObjectsWithTag("Tree");

        //escape boost 
        Debug.Log("Cancelling boost");

            //get the track speed back to normal
        move = track.GetComponent<trackmove>();
        move.speed = 0.5f;
            //current trees back to normal
        for (int i = 0; i < trees.Length; i++)
        {
            trees[i].GetComponent<EnemycarMove>().speed = 5.5f;
        }
            //and newly spawned trees too
            
        if (treeSpawner != null)
        {
            treeSpawner.UpdateSpeed(5.5f);
            treeSpawner.delaytimer = 0.6f;
        }
            //turn boost mode off to allow enemy cars being spawned again
            carSpawner.SetBoost(false);

        cs.delaytimer = oldCoinsDelay;

    }
}
