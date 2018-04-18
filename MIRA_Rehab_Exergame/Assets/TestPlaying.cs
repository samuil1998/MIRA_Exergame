using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlaying : MonoBehaviour {
    public AudioClip bing;
    public AudioClip bump;
    public AudioClip buzz;
    public AudioClip boostsound;


    AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}
	
   
	// Update is called once per frame
	void Update () {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("SPACE");
            Debug.Log("SPACE");
            Debug.Log("SPACE");

            source.PlayOneShot(bing, 0.7f);
        }
        */
	}

    public void Bing()
    {
        source.PlayOneShot(bing, 0.7f);
    }

    public void Bump()
    {
        source.PlayOneShot(bump, 0.7f);
    }

    public void Buzz()
    {
        source.PlayOneShot(buzz, 0.7f);
    }

    public void BoostSound()
    {
        source.PlayOneShot(boostsound, 0.7f);
    }
}
