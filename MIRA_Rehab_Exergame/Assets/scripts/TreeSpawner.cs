using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawner : MonoBehaviour {
    private Camera cam;
    private float cameraHeight;
    private float cameraWidth;
    public GameObject[] trees;
    private int treeNo;
    public float delaytimer = 1f;
    private float timer;
    GameObject shared;
    ShareVariables sv;
    bool pause = false;

    public float treeSpeed = 5.5f;

    // Use this for initialization
    void Start () {
        timer = delaytimer;
        cam = Camera.main;
        cameraHeight = 2f * cam.orthographicSize;
        cameraWidth = cameraHeight * cam.aspect;
        Debug.Log(cameraWidth);

        shared = GameObject.FindGameObjectWithTag("SharedVariables");
        sv = shared.GetComponent<ShareVariables>();

        foreach (GameObject tree in trees)
        {
            tree.GetComponent<EnemycarMove>().speed = treeSpeed;
        }

    }

    // Update is called once per frame
    void Update () {
        pause = sv.getPause();
        if (pause == false)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Vector3 treePos = new Vector3(Random.Range(-cameraWidth / 2, -cameraWidth / 2 + 1.2f), transform.position.y, -8); //get random position in the area above the camera
                // 2.5f keeps the randomly spawned cars off the grass
                treeNo = (int)Random.Range(0, 2); //get random car from the prefabs
                Instantiate(trees[treeNo], treePos, transform.rotation); //instantiate it with the random position

                treePos = new Vector3(Random.Range(cameraWidth / 2, cameraWidth / 2 - 1.2f), transform.position.y, -8); //get random position in the area above the camera
                // 2.5f keeps the randomly spawned cars off the grass
                treeNo = (int)Random.Range(0, 2); //get random car from the prefabs
                Instantiate(trees[treeNo], treePos, transform.rotation); //instantiate it with the random position
                timer = delaytimer; //reset the timer
            }
        }

    }

    public void UpdateSpeed(float newSpeed)
    {
        foreach (GameObject tree in trees)
        {
            tree.GetComponent<EnemycarMove>().speed = newSpeed;
        }
    }
}
