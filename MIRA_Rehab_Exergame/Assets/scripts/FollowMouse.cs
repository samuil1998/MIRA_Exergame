using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FollowMouse : MonoBehaviour {

    private Vector2 mousePosition;
    public float moveSpeed = 0.1f;
    private bool collision = false;
    private bool pause = false;
    GameObject shared;
    ShareVariables sv;
    GameObject countdowner;
    Text timeDisplay;
    bool calledCoroutine = false;


    // Use this for initialization
    void Start () {
        
        shared = GameObject.FindGameObjectWithTag("SharedVariables");
        sv = shared.GetComponent<ShareVariables>();

    }

    // Update is called once per frame
    void Update () {
        pause = sv.getPause();

        //if the car hasn't crashed and the game isn't paused, allow the player to play
        if (collision == false && pause == false)
        {
            
            mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
        }
        //if countdown is scheduled, do it first and only then proceed
        else if (pause == true && sv.getCountdown() == true  && calledCoroutine == false)
        {
            StartCoroutine(Countdown());
            calledCoroutine = true;
        }
            
            
    }

    public void setCollision(bool b)
    {
        collision = b;
    }

    public void stopCar(bool b)
    {
        pause = b;
    }
    
    IEnumerator Countdown()
    {
        //wait for 3 seconds
        countdowner = GameObject.FindGameObjectWithTag("TimeDisplayer");
        timeDisplay = countdowner.GetComponent<Text>();
        timeDisplay.text = "3";
        yield return new WaitForSeconds(1f);
        timeDisplay.text = "2";
        yield return new WaitForSeconds(1f);
        timeDisplay.text = "1";
        yield return new WaitForSeconds(1f);
        timeDisplay.text = "GO!";
        yield return new WaitForSeconds(1f);

        //Destroy(countdowner);
        sv.setPause(false);
        sv.setCountdown(false);

        Destroy(countdowner);

        
    }
}