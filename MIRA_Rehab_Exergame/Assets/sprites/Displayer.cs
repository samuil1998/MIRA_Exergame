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
        else if (result < 30)
        {
            feedback = "Not bad!\n";
        }
        else if (result < 60)
        {
            feedback = "Well done!\n";
        }
        else
        {
            feedback = "Amazing!\n";
        }

        yield return new WaitForSeconds(0.7f);
        scoreDisplay.text = feedback;
        yield return new WaitForSeconds(0.7f);

        int show = 0;
        if (result < 50)
        {
            while (show <= result)
            {
                scoreDisplay.text = feedback + "Score: " + show;
                yield return new WaitForSeconds(0.08f);
                show++;
            }
        }
        //so that the user doesn't wait too much for the points to display
        else if (result < 200)
        {
            while (show <= result)
            {
                scoreDisplay.text = feedback + "Score: " + show;
                yield return new WaitForSeconds(0.03f);
                show++;
            }
        }
        else
        {
            while (show <= result)
            {
                scoreDisplay.text = feedback + "Score: " + show;
                yield return new WaitForSeconds(0.01f);
                show++;
            }
        }

        yield return new WaitForSeconds(0.7f);

        scoreDisplay.text = scoreDisplay.text + "\nLevel: " + sv.difficulty;
    }
}
