﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCollision : MonoBehaviour {
    private Rigidbody2D rb2d;
    GameObject controller;
    int score;
    FollowMouse fm;
    //could be adjusted by the user 
    public float crashDistance = 3.5f;
    public float crashSpeed = 1f;
    public float crashWait = 0.5f;

	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        controller =  GameObject.FindGameObjectWithTag("GameController");
        fm = GetComponent<FollowMouse>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemycar") {
            Debug.Log("Hit an enemy car.");
            Destroy (col.gameObject);

            fm.setCollision(true);
            StartCoroutine(MoveBack(crashSpeed));

            fm.setCollision(false);



        } 
        else if (col.gameObject.tag == "coin") 
        {
            Destroy (col.gameObject);

            score++;
            Debug.Log(score);

            DisplayScore displayer = controller.GetComponent<DisplayScore>();
            displayer.updateScore(score);



        }

        else if (col.gameObject.tag == "Tree") 
        {
            
           // Physics.IgnoreCollision(col.GetComponent<Collider>(), GetComponent<Collider>()); 



        }
        
    }

    IEnumerator MoveBack(float time)
    {
        float elapsedTime = 0;
        Vector2 startingPos = transform.position;
        Vector2 finalPos = transform.position;
        finalPos.y -= crashDistance;
        while (elapsedTime < time)
        {
            transform.position = Vector2.Lerp(startingPos, finalPos, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.5f);
    }
}