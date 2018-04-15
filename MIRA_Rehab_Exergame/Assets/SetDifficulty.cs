﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SetDifficulty : MonoBehaviour {

    GameObject shared;
    ShareVariables sv;
    // Use this for initialization
    void Start () {
        shared = GameObject.FindGameObjectWithTag("SharedVariables");
        sv = shared.GetComponent<ShareVariables>();
    }

    // Update is called once per frame
    void Update () {

    }
    //if you come from pause you need to set pause to false before running a new level
    public void SetEasy()
    {
        if (sv.getPause())
        {
            sv.setPause(false);
        }

        SceneManager.LoadScene("Easy");
        sv.difficulty = "easy";
    }
    public void SetMedium()
    {
        if (sv.getPause())
        {
            sv.setPause(false);
        }
        SceneManager.LoadScene("Medium");
        sv.difficulty = "medium";
    }
    public void SetHard()
    {
        if (sv.getPause())
        {
            sv.setPause(false);
        }
        SceneManager.LoadScene("Hard");
        sv.difficulty = "hard";
    }
}
