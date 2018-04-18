using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisplayInstructions : MonoBehaviour {

	// Use this for initialization
    void Start () {
        StartCoroutine(Instruction());
	}

    IEnumerator Instruction()
    {
        GameObject inst = GameObject.FindGameObjectWithTag("Instructions");
        inst.SetActive(false);
        yield return new WaitForSeconds(1f);
        inst.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
