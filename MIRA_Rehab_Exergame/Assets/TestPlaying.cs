using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlaying : MonoBehaviour {
    public AudioClip bing;
    public AudioClip bump;
    public AudioClip buzz;
    public AudioClip boostsound;
    public ShareVariables sv;


    AudioSource source;
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        sv = GameObject.FindGameObjectWithTag("SharedVariables").GetComponent<ShareVariables>();
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
        if (sv.getVolume() == true)
        {
            source.PlayOneShot(bing, 0.7f);
        }
    }

    public void Bump()
    {
        if (sv.getVolume() == true)
        {
            source.PlayOneShot(bump, 0.7f);
        }
    }

    public void Buzz()
    {
        if (sv.getVolume() == true)
        {
            source.PlayOneShot(buzz, 0.7f);
        }
    }

    public void BoostSound()
    {
        if (sv.getVolume() == true)
        {
            source.PlayOneShot(boostsound, 0.7f);
        }
    }
}
