using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Displayer : MonoBehaviour {
   
    ShareVariables sv;

    Text scoreDisplay;
    GameObject displayer;
    // Use this for initialization
    void Start () {
        sv = GameObject.FindGameObjectWithTag("SharedVariables").GetComponent<ShareVariables>();
        displayer = GameObject.FindGameObjectWithTag("Result");
        scoreDisplay = displayer.GetComponent<Text>();
        scoreDisplay.text = "";
        StartCoroutine(showResult(sv.result));
    }

    // Update is called once per frame
    void Update () {

    }

    public IEnumerator showResult(int result)
    {
        string feedback = "";
        if (result < 10)
        {
            feedback = "You could do better!\n";
        }
        else if (result < 20)
        {
            feedback = "Not bad!\n";
        }
        else if (result > 40)
        {
            feedback = "Amazing!\n";
        }
        else
        {
            feedback = "Well done!\n";
        }

        yield return new WaitForSeconds(0.7f);
        scoreDisplay.text = feedback;
        yield return new WaitForSeconds(0.7f);

        int show = 0;
        while (show <= result)
        {
            scoreDisplay.text = feedback + "Score: " + show;
            yield return new WaitForSeconds(0.1f);
            show++;
        }

        yield return new WaitForSeconds(0.7f);

        scoreDisplay.text = scoreDisplay.text + "\nLevel: " + sv.difficulty;
    }
}
