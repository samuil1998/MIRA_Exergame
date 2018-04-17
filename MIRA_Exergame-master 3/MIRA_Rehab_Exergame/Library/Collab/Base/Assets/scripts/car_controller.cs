using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_controller : MonoBehaviour {

    private int score = 0;
    bool collision = false;
    Rigidbody2D rb2d;
    public int Score
    {
        get{return Score;}
    }

	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}

    void Update()
    {
        if (collision == false)
        {
            Vector2 temp = Camera.main.ScreenToWorldPoint(Input.mousePosition); //map from screen to game world 
            transform.position = temp; //make the object follow the cursor of the mouse
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
		}
    }

    IEnumerator MoveBack(Vector2 old_position, float time)
    {
        float elapsedTime = 0;
        Vector2 startingPos = transform.position;
        while (elapsedTime < time)
        {
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
        StartCoroutine(MoveBack(old_position, 0.5f));


        collision = false;
        rb2d.velocity = Vector2.zero;
    }
    //delete later
}