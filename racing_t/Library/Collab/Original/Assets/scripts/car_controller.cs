using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_controller : MonoBehaviour {

    private int score = 0;
    bool collision = false;
    Rigidbody2D rb2d;
    GameObject controller;
    DisplayPoints displayPoints;



	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        controller = GameObject.FindWithTag ("GameController");
        displayPoints = controller.GetComponent<DisplayPoints>();
	}

    void Update()
    {
        if (collision == false)
        {
            Vector2 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //map from screen to game world 
            transform.position = cursorPosition; //make the object follow the cursor of the mouse
        }
        else
        {
            Vector2 xPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            xPosition.y = transform.position.y;
            transform.position = xPosition;
        }
    }

	void OnCollisionEnter2D(Collision2D col)
    {
        collision = true;
		if (col.gameObject.tag == "Enemycar") {
			Destroy (col.gameObject);
			StartCoroutine (Crash ());
		} 
		else if (col.gameObject.tag == "coin") 
		{
            Destroy (col.gameObject);
            collision = false;
            score++;
            displayPoints.updateScore(score);
           
		}
    }

    IEnumerator MoveBack(Vector2 old_position, float time)
    {
        float elapsedTime = 0;
        Vector2 startingPos = transform.position;
        while (elapsedTime < time)
        {
            old_position.x = transform.position.x;
            transform.position = Vector2.Lerp(startingPos, old_position, (elapsedTime / time));
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }       

    IEnumerator Crash()
    {
        Vector2 old_position = transform.position;
        rb2d.AddForce(new Vector2(0f, -100f));
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(MoveBack(old_position, 0.7f));
        collision = false;
        rb2d.velocity = Vector2.zero;
    }
    //delete later
}