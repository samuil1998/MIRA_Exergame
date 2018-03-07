using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {
    GameObject displayer;
    // Use this for initialization
    void Start () {
        displayer = GameObject.FindGameObjectWithTag("PointsDisplayer");
        updateScore(0);
    }

    // Update is called once per frame
    void Update () {

    }

    public void updateScore(int score)
    {
        Text scoreDisplay = displayer.GetComponent<Text>();
        scoreDisplay.text = "SCORE: " + score;
    }
}
