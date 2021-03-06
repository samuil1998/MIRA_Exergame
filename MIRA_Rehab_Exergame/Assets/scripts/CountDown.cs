﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CountDown : MonoBehaviour {

    public AudioClip buzz;
    private AudioSource source;
    private GameObject countdownDisplayer;
    private Text text;
    private GameObject car;
    private GameObject coinSpawner;
    private GameObject carSpawner;
    private GameObject tyreSpawner;
    private GameObject fuelSpawner;
    private ShareVariables sv;

    void OnEnable()
    {
        countdownDisplayer = GameObject.FindGameObjectWithTag("Countdown");
        text = countdownDisplayer.GetComponent<Text>();
        SceneManager.sceneLoaded += StartCountDown;
        car = GameObject.FindGameObjectWithTag("Car");
        coinSpawner = GameObject.FindGameObjectWithTag("CoinSpawner");
        tyreSpawner = GameObject.FindGameObjectWithTag("TyreSpawner");
        fuelSpawner = GameObject.FindGameObjectWithTag("FuelSpawner");
        carSpawner = GameObject.FindGameObjectWithTag("CarSpawner");

        source = GetComponent<AudioSource>();
        sv = GameObject.FindGameObjectWithTag("SharedVariables").GetComponent<ShareVariables>();
    }
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void StartCountDown(Scene scene, LoadSceneMode mode)
    {
        //the if statement is needed to prevent countdown when the pause scene is loaded 'on top' of the game
        if (scene.name == "Easy" || scene.name == "Medium" || scene.name == "Hard")
        {
            StartCoroutine(WaitOneSecond());
        }
    }

    IEnumerator WaitOneSecond()
    {
        
        text.text = "3";
        if (sv.getVolume()) source.PlayOneShot(buzz, 0.7f);
        yield return new WaitForSeconds(1);
        text.text = "2";
        if (sv.getVolume()) source.PlayOneShot(buzz, 0.7f);
        yield return new WaitForSeconds(1);
        text.text = "1";
        if (sv.getVolume()) source.PlayOneShot(buzz, 0.7f);
        yield return new WaitForSeconds(1);
        text.text = "Go!";
        if (sv.getVolume()) source.PlayOneShot(buzz, 0.7f);
        yield return new WaitForSeconds(1);
        text.text = "";

        car.GetComponent<FollowMouse>().enabled = true;
        coinSpawner[] coinspawners = coinSpawner.GetComponents<coinSpawner>();
        Debug.Log("there");
        foreach (coinSpawner cs in coinspawners)
        {
            cs.enabled = true;
        }
        //need the part above as the coinspawner has two identical components - one for yellow coins and one for red ones
        tyreSpawner.GetComponent<coinSpawner>().enabled = true;
        fuelSpawner.GetComponent<coinSpawner>().enabled = true;
        carSpawner.GetComponent<carspawner>().enabled = true;

    }

    void OnDisable()
    {
        Debug.Log("OnDisable");
        SceneManager.sceneLoaded -= StartCountDown;
    }
}
