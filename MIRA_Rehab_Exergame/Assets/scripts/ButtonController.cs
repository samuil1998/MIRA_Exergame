using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ButtonController : MonoBehaviour {

    GameObject shared;
    ShareVariables sv;

	void Start () {
        
        shared = GameObject.FindGameObjectWithTag("SharedVariables");
        sv = shared.GetComponent<ShareVariables>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartGame()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void GoHome()
    {
        SceneManager.LoadScene("HomePage");
    }

    public void Pause()
    {
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
        sv.setPause(true);
        GameObject obj = GameObject.FindGameObjectWithTag("PauseButton");
        Debug.Log("so far so good");
        obj.GetComponent<Image>().enabled = false;
    }

    public void ResumeGame()
    {
        sv.setPause(false);
        SceneManager.UnloadScene("Pause");
        GameObject obj = GameObject.FindGameObjectWithTag("PauseButton");
        Debug.Log("so far so good");
        obj.GetComponent<Image>().enabled = true;
    }

    public void turnObstacles()
    {
        GameObject go = GameObject.FindGameObjectWithTag("SharedVariables");
        ShareVariables sv = go.GetComponent<ShareVariables>();
        sv.resetObstacles();
    }

    public void InGameSettings()
    {
        SceneManager.LoadScene("PauseSettings", LoadSceneMode.Additive);
        SceneManager.UnloadScene("Pause");

    }

    public void BackToPause()
    {
        SceneManager.UnloadScene("PauseSettings");
        SceneManager.LoadScene("Pause", LoadSceneMode.Additive);
    }
}

