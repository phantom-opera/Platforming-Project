using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

	//Starts the game, main menu, control menu, or exit the game depending on what button the player presses.

	public void newGame()
	{
		Cursor.visible = false;
		SceneManager.LoadScene("MainGame");
	}

	public void mainMenu()
	{
		SceneManager.LoadScene("MainMenu");
	}

	public void controlMenu()
	{
		SceneManager.LoadScene("Controls");
	}

	public void exitGame()
	{
		Application.Quit();
	}
}
