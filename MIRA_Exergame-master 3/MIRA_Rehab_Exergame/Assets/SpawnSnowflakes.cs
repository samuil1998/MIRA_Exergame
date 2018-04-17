using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSnowflakes : MonoBehaviour {

    public GameObject snowflake;
    public float delaytimer = 1f;
    private float timer;
    GameObject shared;
    ShareVariables sv;
    bool pause = false;
    private float randomSpeed;

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
                randomSpeed = Random.Range(6, 8);
                Vector2 snowflakePos = new Vector2(Random.Range(-8f, 8f), transform.position.y);
                snowflake.GetComponent<EnemycarMove>().speed = randomSpeed;
                Instantiate(snowflake, snowflakePos, transform.rotation);
                timer = delaytimer;
            }
        }
    }
}
