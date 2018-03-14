using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawner : MonoBehaviour {

    public GameObject coin;
	public float delaytimer = 1f;
	private float timer;
    GameObject shared;
    ShareVariables sv;
    bool pause = false;

	// Use this for initialization
	void Start () {
		timer = delaytimer;
        shared = GameObject.FindGameObjectWithTag("SharedVariables");
        sv = shared.GetComponent<ShareVariables>();
	}

	// Update is called once per frame
	void Update () {
        pause = sv.getPause();
        if (pause == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Vector2 coinPos = new Vector2(Random.Range(-1.95f, 2.0f), transform.position.y);
                Instantiate(coin, coinPos, transform.rotation);
                timer = delaytimer;
            }
        }
    }
}
