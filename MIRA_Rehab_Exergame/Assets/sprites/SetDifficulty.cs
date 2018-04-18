using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SetDifficulty : MonoBehaviour {

    GameObject inst;

    GameObject shared;
    ShareVariables sv;
    // Use this for initialization
    void Start () {
        shared = GameObject.FindGameObjectWithTag("SharedVariables");
        sv = shared.GetComponent<ShareVariables>();
        inst = GameObject.FindGameObjectWithTag("Instructions");
        inst.SetActive(false);
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

        GameObject.FindGameObjectWithTag("Options").SetActive(false);

        inst.SetActive(true);
        StartCoroutine(StartLevel("Easy"));
    }
    public void SetMedium()
    {
        if (sv.getPause())
        {
            sv.setPause(false);
        }

        GameObject.FindGameObjectWithTag("Options").SetActive(false);

        inst.SetActive(true);
        StartCoroutine(StartLevel("Medium"));
    }
    public void SetHard()
    {
        if (sv.getPause())
        {
            sv.setPause(false);
        }

        GameObject.FindGameObjectWithTag("Options").SetActive(false);

        inst.SetActive(true);
        StartCoroutine(StartLevel("Hard"));
    }

    IEnumerator StartLevel(string level)
    {
        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(level);
        sv.difficulty = level;
    }
}
