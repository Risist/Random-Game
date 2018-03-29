using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TempMenu : MonoBehaviour {

	public void ButtonSiege()
	{
		SceneManager.LoadScene(2);
	}
	public void ButtonTutorial()
	{
		SceneManager.LoadScene(1);
	}
	public void ButtonExit()
	{
		Application.Quit();
	}
}
