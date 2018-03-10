using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour 
{	

	public void Homepage()
	{
		SceneManager.LoadScene (0);
	}

	public void Setting()
	{
		Debug.Log("setting");
		SceneManager.LoadScene (1);
	}

	public void Difficulty_level()
	{
		SceneManager.LoadScene (2);
	}

	public void Easy()
	{
		SceneManager.LoadScene (3);
	}

//	public void Medium()
//	{
//		SceneManager.LoadScene (1);
//	}

	public void Hard()
	{
		SceneManager.LoadScene (4);
	}

}
