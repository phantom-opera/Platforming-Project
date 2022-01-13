using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{

	public GameObject healthText;
	public static int health;

	// Update is called once per frame

	void Start()
	{
		 health = 3; //Player's starting health is 3.
    }

	void Update()
    {
		healthText.GetComponent<Text>().text = "HEALTH: " + health;
		CheckGameOver();
	}

	void CheckGameOver()
	{
		if(health < 1) //If health falls below 1
		{

			//Make the player's cursor visible again and send them to the game over screen.
			Time.timeScale = 0.25f;
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
			SceneManager.LoadScene("GameOver");
		}
	}
}
